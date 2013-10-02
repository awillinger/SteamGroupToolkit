using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Harvester
{
    public class SteamBackend
    {
        #region Attributes
        // URL to Steam's Login System
        private readonly String backendURL = "steamcommunity.com/login/";
        // Communcation with Steam
        private WebClient wc;

        // Steam Cookie
        private String cookie;
        // 8 Char SessionID (NOT COOKIE!)
        private String sessionID;

        // SteamID64 of the Inviter
        private long senderID;
        #endregion

        #region Contructor
        public SteamBackend()
        {
            this.wc = new WebClient();

            this.cookie = "";
            this.sessionID = "";
        }
        #endregion

        #region Enums
        /// <summary>
        /// Login Results, might be incomplete
        /// </summary>
        public enum ELoginResult
        {
            LoginResult_Failure = 0,
            LoginResult_Ok =  1,
            LoginResult_SteamGuard = 2,
            LoginResult_MissingKey = 3,
            LoginResult_BackendDown = 4
        };

        #endregion

        #region Methods

        /// <summary>
        /// Retreive the RSA Public Key from Steam.
        /// This is required to encrypt the Password later when logging in.
        /// </summary>
        /// <param name="username">Steam Username to get the RSA Key for</param>
        /// <returns>
        /// Index 0: Modulus
        /// Index 1: Exponent
        /// Index 2: RSA Timestamp
        /// </returns>
        public String[] getRSAKey(String username)
        {
            // create the URL
            String queryURL = "https://" + this.backendURL + "getrsakey";
            this.wc.Encoding = System.Text.Encoding.UTF8;

            // this is required to send the login data like you would in a web browser
            this.wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //this.wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/534.30 (KHTML, like Gecko) Chrome/12.0.742.100 Safari/534.30");

            // json-encoded response from steam
            String rawResponse = this.wc.UploadString(queryURL, "username="+username+"&donotcache=133828291");

            // we didn't get any data, exiting
            if (rawResponse == null) return null;
            JObject jData;

            try
            {
                jData = JObject.Parse(rawResponse);
                // failure while getting the RSA key, might be because of a wrong username
                if ((bool)jData["success"] == false) return null;

                // temp array to hold the entries
                String[] key = new String[3];
                key[0] = (String)jData["publickey_mod"];
                key[1] = (String)jData["publickey_exp"];
                key[2] = (String)jData["timestamp"];
                return key;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// Login into Steam using the (non-)official Login API.
        /// Also handles SteamGuard
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="emailauth"></param>
        /// <returns></returns>
        public ELoginResult doLogin(String username, String password, String emailauth = null)
        {
            // Get the RSA key - required to encrypt our password
            String[] key = this.getRSAKey(username);
            if (key == null) return ELoginResult.LoginResult_MissingKey;

            // create the url
            String queryURL = "https://" + backendURL + "dologin";

            // setup our object containing the public key information
            RSAParameters param = new RSAParameters();
            param.Modulus = SteamBackend.StringToByteArray(key[0]);
            param.Exponent = SteamBackend.StringToByteArray(key[1]);
            byte[] plain = Encoding.UTF8.GetBytes(password);

            // encrypt the plain password using our public key
            String encrypted = System.Convert.ToBase64String(SteamBackend.RSAEncrypt(plain, param));

            // setup POST data
            NameValueCollection data = new NameValueCollection
            {
                { "password", encrypted },
                { "username", username },
                { "rsatimestamp", key[2] },
                { "remember_login", "false" },
                { "emailauth", emailauth },
                { "donotcache", "" }
            };

            // send the request
            String response = Encoding.UTF8.GetString(this.wc.UploadValues(queryURL, data));

            // something bad happened
            if (response == null) return ELoginResult.LoginResult_BackendDown;

            // setup an object which contains all headers that the server sent us
            WebHeaderCollection wh = this.wc.ResponseHeaders;

            for (int i = 0; i < wh.Count; i++)
            {
                // get the cookie
                if (wh.GetKey(i).Equals("Set-Cookie"))
                {
                    String[] cookie = wh.Get(i).Split(';');
                    this.cookie = cookie[0];

                    break;
                }
            }

            JObject jData = JObject.Parse(response);

            bool success = (bool)jData["success"];

            // login completed
            if (success && (bool)jData["login_complete"])
            {
                long steamid = (long)jData["transfer_parameters"]["steamid"];

                // setup the variables
                this.senderID = steamid;
                this.wc.Headers.Add("Cookie", this.cookie);

                // get the per-login sessionid
                String raw = wc.DownloadString("http://steamcommunity.com/profiles/" + steamid);
                Match m = Regex.Match(raw, "g_sessionID = \"(.*?)\"", RegexOptions.IgnoreCase);

                this.sessionID = m.Groups[1].Value;

                return ELoginResult.LoginResult_Ok;
            }
            // login failure
            else
            {
                // steam guard protected account
                if ((bool)jData["emailauth_needed"])
                {
                    return ELoginResult.LoginResult_SteamGuard;
                }
                else
                {
                    return ELoginResult.LoginResult_Failure;
                }
            }
        }

        #endregion

        #region Getter/Setter Methods
        public long getSenderID()
        {
            return this.senderID;
        }

        public String getSessionID()
        {
            return this.sessionID;
        }

        public String getCookie()
        {
            return this.cookie;
        }

        public WebClient getSession()
        {
            return this.wc;
        }

        #endregion

        #region Miscellaneous Methods
        /// <summary>
        /// Converts a Hex-String to a Byte Array
        /// </summary>
        /// <param name="hex">String representation of a Hex</param>
        /// <returns>Byte-Array</returns>
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Encrypt a Byte Array with a RSA Public Key
        /// </summary>
        /// <param name="data">Raw Data as a byte array</param>
        /// <param name="keyInfo">Public Key</param>
        /// <returns>Encrypted Data</returns>
        public static byte[] RSAEncrypt(byte[] data, RSAParameters keyInfo)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(keyInfo);  
                encryptedData = rsa.Encrypt(data, false);
            }
            return encryptedData;
        }
        #endregion
    }
}
