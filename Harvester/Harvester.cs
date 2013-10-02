using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Harvester
{
    public class Harvester
    {
        #region Attributes
        private HarvesterGUI gui;
        #endregion

        #region Contructor
        public Harvester(HarvesterGUI gui)
        {
            this.gui = gui;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all Members from the specified Group
        /// </summary>
        /// <param name="name">Unique Group name</param>
        public void getMembers(String name, String prefix)
        {
            WebClient wc = new WebClient();

            // has next page
            bool bNextpage = true;
            // current page
            int iPage = 1;
            // amount of members parsed
            int iCount = 0;
            List<String> harvested = new List<String>();

            while (bNextpage)
            {
                try
                {
                    String result = "";

                    do
                    {
                        result = wc.DownloadString("http://steamcommunity.com/groups/" + name + "/memberslistxml?xml=1&p=" + iPage);
                    } while (result.Length < 1 || result.IndexOf("unavailable") > 0);

                    // read xml
                    Match m1 = Regex.Match(result, @"<totalPages>([0-9]+)</totalPages>", RegexOptions.IgnoreCase);
                    Match m2 = Regex.Match(result, @"<nextPageLink><!\[CDATA\[(.*?)\]\]></nextPageLink>", RegexOptions.IgnoreCase);
                    Match m3 = Regex.Match(result, @"<memberCount>([0-9]+)</memberCount>", RegexOptions.IgnoreCase);
                    Match m4 = Regex.Match(result, @"<avatarMedium><!\[CDATA\[(.*?)\]\]></avatarMedium>", RegexOptions.IgnoreCase);
                    MatchCollection m5 = Regex.Matches(result, @"<steamID64>([0-9]+)</steamID64>", RegexOptions.IgnoreCase);

                    String totalPages = m1.Groups[1].Value;
                    String nextPageLink = m2.Groups[1].Value;
                    String memberCount = m3.Groups[1].Value;
                    String avatarMedium = m4.Groups[1].Value;

                    // has next page
                    if (isUrl(nextPageLink))
                    {
                        iPage++;
                    }
                    else
                    {
                        // stop parsing
                        bNextpage = false;
                    }

                    List<String> o = new List<String>();
                    String tmp;

                    foreach (Match member in m5)
                    {
                        tmp = member.Groups[1].Value;
                        o.Add(tmp);
                        
                        if (harvested.IndexOf(tmp) < 0)
                        {
                            harvested.Add(tmp);
                        }
                        iCount++;

                    }

                    // update labels
                    this.gui.SetControlPropertyValue(this.gui.getMembersLabel(), "Text", String.Format("{0:n0}", int.Parse(memberCount)));
                    this.gui.SetControlPropertyValue(this.gui.getCurrentPageLabel(), "Text", "" + iPage);
                    this.gui.SetControlPropertyValue(this.gui.getTotalPagesLabel(), "Text", totalPages);
                    this.gui.SetControlPropertyValue(this.gui.getParsedLabel(), "Text", "" + String.Format("{0:n0}", harvested.Count));

                    this.gui.getAvatarBox().Load(avatarMedium);
                }
                catch (System.Threading.ThreadAbortException t)
                {
                    // parsing ended permaturely, save data to disk
                    File.WriteAllLines(prefix+"_"+name+".txt", harvested.ToArray());
                }
            }

            // save data to disk
            File.WriteAllLines(prefix + "_" + name + ".txt", harvested.ToArray());
        }
        #endregion

        #region Miscellanous Methods
        /// <summary>
        /// Check if a URL got a valid format.
        /// </summary>
        /// <param name="url">The URL to check</param>
        /// <returns>true if it's a valid URL, false if not</returns>
        private static bool isUrl(String url)
        {
            if (url.Length < 5) return false;
            Match match = Regex.Match(url, @"https?\:\/\/(www.)?([a-zA-Z]+)\.([a-zA-Z]{1,3})\/?(.*?)$", RegexOptions.IgnoreCase);

            return match.Success;
        }

        /// <summary>
        /// Add leading 0's to a Number
        /// </summary>
        /// <param name="number">Number to format</param>
        /// <returns>formatted Number</returns>
        private static String FormatNumber(int number)
        {
            if (number < 100 && number > 10)
            {
                return "0" + number;
            }
            else if (number < 10)
            {
                return "00" + number;
            }
            else
            {
                return "" + number;
            }
        }
        #endregion
    }
}
