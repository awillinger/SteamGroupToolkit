using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Harvester
{
    public partial class HarvesterGUI : Form
    {
        #region Attributes/Deleagate Definition
        //declare the delegate
        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        private SteamBackend mBackend;
        private Thread mThread;
        private Thread mInviter;
        private Harvester mHarvester;
        private Inviter hInviter;

        private String mFileName;
        private String mBaseFileName;
        private long mGroupID;
        #endregion

        #region Constructor
        public HarvesterGUI()
        {
            InitializeComponent();

            this.mBackend = new SteamBackend();

            this.mHarvester = new Harvester(this);
            this.hInviter = new Inviter(this.mBackend);

            this.mThread = new Thread(delegate()
            {
                mHarvester.getMembers(this.tGroupURLData.Text, this.mBaseFileName);
            });
            this.mThread.IsBackground = true;

            this.mFileName = "";
            this.mBaseFileName = "";
            this.mGroupID = -1;

            this.loadConfiguration();
        }
        #endregion

        #region Event Handlers
        private void bStart_Click(object sender, EventArgs e)
        {
            this.mThread = new Thread(delegate()
            {
                mHarvester.getMembers(this.tGroupURLData.Text, this.mBaseFileName);
            });
            this.mThread.Start();
            this.bStart.Enabled = false;
            this.bStop.Enabled = true;
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            this.mThread.Abort();
            this.bStart.Enabled = true;
            this.bStop.Enabled = false;
        }

        private void bSource_Click(object sender, EventArgs e)
        {
            ofSource.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ofSource.Title = "Open Harvester File";
            ofSource.FileName = "";

            if (ofSource.ShowDialog() != DialogResult.Cancel)
            {
                this.mFileName = ofSource.FileName;
                this.tSource.Text = ofSource.FileName;
            }
        }

        private void bStartInviter_Click(object sender, EventArgs e)
        {
            if (this.bStartInviter.Text.Equals("Start"))
            {
                this.bStartInviter.Text = "Stop";

                this.hInviter.loadFile(this.mFileName);
                int iInterval = 0;
                try
                {
                    iInterval = (int.Parse(this.tInterval.Text)) * 1000;
                }
                catch (FormatException ex)
                {
                    iInterval = 1000;
                }

                this.mInviter = new Thread(delegate()
                    {
                        while (true)
                        {
                            try
                            {
                                String target = this.hInviter.getNextSteamid();
                                // this.mBackend
                                Inviter.EInviterResult result = this.hInviter.sendInvite(this.mGroupID, long.Parse(target));
                                this.hInviter.updateState(target, result);
                                SetControlPropertyValue(this.tHistory, "Text", this.hInviter.getHistory());
                            }
                            catch (ThreadAbortException ae)
                            {
                            }
                            Thread.Sleep(iInterval);
                        }
                    });
                this.mInviter.IsBackground = true;
                this.mInviter.Start();
            }
            else
            {
                this.bStartInviter.Text = "Start";
                this.mInviter.Abort();

                this.hInviter.saveFile(this.mFileName);
            }
        }

        private void bLoginInviter_Click(object sender, EventArgs e)
        {
            handleLogin(this.mBackend.doLogin(this.tUsername.Text, this.tPassword.Text));            
        }
        #endregion

        #region Methods

        private void loadConfiguration()
        {
            String input = File.ReadAllText("settings.json");

            if (input == null) Application.Exit();
            JObject json = JObject.Parse(input);

            this.mBaseFileName = (String)json["file_prefix"];
            this.mGroupID = (long)json["group_id"];
        }

        private void handleLogin(SteamBackend.ELoginResult result)
        {
            switch (result)
            {
                case SteamBackend.ELoginResult.LoginResult_Failure:
                    MessageBox.Show("Login failed!");
                    break;
                case SteamBackend.ELoginResult.LoginResult_Ok:
                    MessageBox.Show("Login successful!");
                    this.bStartInviter.Enabled = true;
                    this.bLoginInviter.Enabled = false;
                    this.tUsername.Enabled = false;
                    this.tPassword.Enabled = false;
                    break;
                case SteamBackend.ELoginResult.LoginResult_SteamGuard:
                    String auth = Microsoft.VisualBasic.Interaction.InputBox("Steam Guard Code required:", "Steam Guard protected");
                    handleLogin(this.mBackend.doLogin(this.tUsername.Text, this.tPassword.Text, auth));
                    break;
            }
        }
        #endregion

        #region Getters
        public Label getMembersLabel()
        {
            return this.lblMembersData;
        }

        public Label getTotalPagesLabel()
        {
            return this.lblTotalPagesData;
        }

        public Label getCurrentPageLabel()
        {
            return this.lblCurrentPageData;
        }

        public Label getParsedLabel()
        {
            return this.lblParsedData;
        }

        public PictureBox getAvatarBox()
        {
            return this.pAvatar;
        }
        #endregion
        // the function that sets properties on the UI control
        public void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                System.Reflection.PropertyInfo[] props = t.GetProperties();
                foreach (System.Reflection.PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }
    }
}
