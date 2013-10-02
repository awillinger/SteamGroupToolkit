using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Harvester
{
    public class Inviter
    {
        #region Attributes
        private SteamBackend backend;

        // contains all unsent invites
        private List<String> pending;
        // sent invites, with status
        private Dictionary<String, EInviterResult> sent;

        private Dictionary<EInviterResult, String> states;
        #endregion

        #region Enums
        public enum EInviterResult
        {
            InviterResult_Ok,
            InviterResult_Failed,
            InviterResult_Duplicate,
            InviterResult_MissingKey
        };
        #endregion

        #region Constructor
        public Inviter(SteamBackend backend)
        {
            this.backend = backend;

            this.pending = new List<String>();
            this.sent = new Dictionary<String, EInviterResult>();

            this.states =  new Dictionary<EInviterResult, String>();
            this.states.Add(EInviterResult.InviterResult_Ok, "Success");
            this.states.Add(EInviterResult.InviterResult_Failed, "Failed");
            this.states.Add(EInviterResult.InviterResult_Duplicate, "Duplicate");
            this.states.Add(EInviterResult.InviterResult_MissingKey, "Missing Key");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Load a file into memory to use for inviting.
        /// </summary>
        /// <param name="filename">The FQ filename (with path)</param>
        /// <returns>true if file was loaded, false if not</returns>
        public bool loadFile(String filename)
        {
            if (!File.Exists(filename)) return false;

            // temporary array to keep all lines
            String[] temp = File.ReadAllLines(filename);

            if (temp.Length == 0) return false;

            this.pending.Clear();
            this.sent.Clear();

            // iterate over all entries and add into the pending list
            foreach (String t in temp)
            {
                this.pending.Add(t);
            }

            return true;
        }

        /// <summary>
        /// Saves all pending Entries into a file.
        /// </summary>
        /// <param name="fileName">The FQ filename (with name)</param>
        public void saveFile(String fileName)
        {
            EInviterResult res;

            // iterate over all still pending entries
            for (int i = 0; i < this.pending.Count; i++)
            {
                if (this.sent.TryGetValue(this.pending[i], out res))
                {
                    // invite has been sent successfully, remove from pending
                    if (res == EInviterResult.InviterResult_Ok || res == EInviterResult.InviterResult_Duplicate)
                    {
                        this.pending.RemoveAt(i);
                    }
                }
            }

            // delete file if it already exists & save data
            File.Delete(fileName);
            File.WriteAllLines(fileName, this.pending.ToArray());
        }

        /// <summary>
        /// Returns a new SteamID to invite
        /// </summary>
        /// <returns></returns>
        public String getNextSteamid()
        {
            // iterate over all pending entries and check against already sent
            for (int i = 0; i < this.pending.Count; i++)
            {
                if (!this.sent.ContainsKey(this.pending[i])) return this.pending[i];                
            }
            return "";
        }

        /// <summary>
        /// Get a list of all past sent invites.
        /// </summary>
        /// <param name="limit">Maximum entries to get</param>
        /// <returns>A String representation of the past sent Invites</returns>
        public String getHistory(short limit = 10)
        {
            String rows = "";

            foreach (var item in this.sent.Reverse())
            {
                String result = "";
                this.states.TryGetValue(item.Value, out result);
                
                // key: SteamID64
                // result: Result
                rows += item.Key + "    " + result + "\n";

                limit--;
                if (limit == 0) break;
            }
            return rows;
        }

        /// <summary>
        /// Updates the State of a specified SteamID64
        /// </summary>
        /// <param name="steamid">SteamID64</param>
        /// <param name="state">new State</param>
        public void updateState(String steamid, EInviterResult state)
        {
            this.sent.Add(steamid, state);
        }

        /// <summary>
        /// Send an Invite to a specified User
        /// </summary>
        /// <param name="groupID">GroupID64</param>
        /// <param name="receiverID">Invitee</param>
        /// <returns></returns>
        public EInviterResult sendInvite(long groupID, long receiverID)
        {
            // reset Cookie header
            this.backend.getSession().Headers.Remove("Cookie");
            this.backend.getSession().Headers.Add("Cookie", this.backend.getCookie() + ";sessionid=" + this.backend.getSessionID());

            // construct request url
            String request = "http://steamcommunity.com/actions/GroupInvite?type=groupInvite&inviter=" + this.backend.getSenderID() + "&invitee=" + receiverID + "&group=" + groupID + "&sessionID=" + this.backend.getSessionID();
            String result = this.backend.getSession().DownloadString(request);

            Match m1 = Regex.Match(result, @"<results><!\[CDATA\[(.*?)\]\]></results>", RegexOptions.IgnoreCase);
            Match m2 = Regex.Match(result, @"<duplicate><!\[CDATA\[([0-9])\]\]></duplicate>", RegexOptions.IgnoreCase);

            switch (m1.Groups[1].Value)
            {
                case "OK":
                    if (m2.Success)
                        return Inviter.EInviterResult.InviterResult_Duplicate;
                    else
                        return Inviter.EInviterResult.InviterResult_Ok;

                default:
                    return Inviter.EInviterResult.InviterResult_Failed;
            }
        }
        #endregion
    }
}
