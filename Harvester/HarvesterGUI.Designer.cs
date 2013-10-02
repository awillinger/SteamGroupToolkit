namespace Harvester
{
    partial class HarvesterGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HarvesterGUI));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabHarvester = new System.Windows.Forms.TabPage();
            this.bStop = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.gInformation = new System.Windows.Forms.GroupBox();
            this.pAvatar = new System.Windows.Forms.PictureBox();
            this.lblParsedData = new System.Windows.Forms.Label();
            this.lblTotalPagesData = new System.Windows.Forms.Label();
            this.lblCurrentPageData = new System.Windows.Forms.Label();
            this.lblParsed = new System.Windows.Forms.Label();
            this.lblTotalPages = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblMembersData = new System.Windows.Forms.Label();
            this.lblMembers = new System.Windows.Forms.Label();
            this.tGroupURLData = new System.Windows.Forms.TextBox();
            this.lblGroupURLPrefix = new System.Windows.Forms.Label();
            this.lblGroupURL = new System.Windows.Forms.Label();
            this.tabInviter = new System.Windows.Forms.TabPage();
            this.bSource = new System.Windows.Forms.Button();
            this.tSource = new System.Windows.Forms.TextBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.bLoginInviter = new System.Windows.Forms.Button();
            this.bStartInviter = new System.Windows.Forms.Button();
            this.gData = new System.Windows.Forms.GroupBox();
            this.lblIntervalData = new System.Windows.Forms.Label();
            this.tInterval = new System.Windows.Forms.TextBox();
            this.tUsername = new System.Windows.Forms.TextBox();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.ofSource = new System.Windows.Forms.OpenFileDialog();
            this.tHistory = new System.Windows.Forms.RichTextBox();
            this.tabMain.SuspendLayout();
            this.tabHarvester.SuspendLayout();
            this.gInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvatar)).BeginInit();
            this.tabInviter.SuspendLayout();
            this.gData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabHarvester);
            this.tabMain.Controls.Add(this.tabInviter);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(460, 260);
            this.tabMain.TabIndex = 0;
            // 
            // tabHarvester
            // 
            this.tabHarvester.Controls.Add(this.bStop);
            this.tabHarvester.Controls.Add(this.bStart);
            this.tabHarvester.Controls.Add(this.gInformation);
            this.tabHarvester.Location = new System.Drawing.Point(4, 22);
            this.tabHarvester.Name = "tabHarvester";
            this.tabHarvester.Size = new System.Drawing.Size(452, 234);
            this.tabHarvester.TabIndex = 0;
            this.tabHarvester.Text = "Harvester";
            this.tabHarvester.UseVisualStyleBackColor = true;
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(230, 170);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(200, 50);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(20, 170);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(200, 50);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // gInformation
            // 
            this.gInformation.Controls.Add(this.pAvatar);
            this.gInformation.Controls.Add(this.lblParsedData);
            this.gInformation.Controls.Add(this.lblTotalPagesData);
            this.gInformation.Controls.Add(this.lblCurrentPageData);
            this.gInformation.Controls.Add(this.lblParsed);
            this.gInformation.Controls.Add(this.lblTotalPages);
            this.gInformation.Controls.Add(this.lblCurrentPage);
            this.gInformation.Controls.Add(this.lblMembersData);
            this.gInformation.Controls.Add(this.lblMembers);
            this.gInformation.Controls.Add(this.tGroupURLData);
            this.gInformation.Controls.Add(this.lblGroupURLPrefix);
            this.gInformation.Controls.Add(this.lblGroupURL);
            this.gInformation.Location = new System.Drawing.Point(3, 3);
            this.gInformation.Name = "gInformation";
            this.gInformation.Size = new System.Drawing.Size(446, 150);
            this.gInformation.TabIndex = 0;
            this.gInformation.TabStop = false;
            this.gInformation.Text = "Group Information";
            // 
            // pAvatar
            // 
            this.pAvatar.Image = ((System.Drawing.Image)(resources.GetObject("pAvatar.Image")));
            this.pAvatar.InitialImage = ((System.Drawing.Image)(resources.GetObject("pAvatar.InitialImage")));
            this.pAvatar.Location = new System.Drawing.Point(45, 60);
            this.pAvatar.Name = "pAvatar";
            this.pAvatar.Size = new System.Drawing.Size(64, 64);
            this.pAvatar.TabIndex = 12;
            this.pAvatar.TabStop = false;
            // 
            // lblParsedData
            // 
            this.lblParsedData.AutoSize = true;
            this.lblParsedData.Location = new System.Drawing.Point(370, 102);
            this.lblParsedData.Name = "lblParsedData";
            this.lblParsedData.Size = new System.Drawing.Size(27, 13);
            this.lblParsedData.TabIndex = 11;
            this.lblParsedData.Text = "N/A";
            // 
            // lblTotalPagesData
            // 
            this.lblTotalPagesData.AutoSize = true;
            this.lblTotalPagesData.Location = new System.Drawing.Point(370, 70);
            this.lblTotalPagesData.Name = "lblTotalPagesData";
            this.lblTotalPagesData.Size = new System.Drawing.Size(27, 13);
            this.lblTotalPagesData.TabIndex = 10;
            this.lblTotalPagesData.Text = "N/A";
            // 
            // lblCurrentPageData
            // 
            this.lblCurrentPageData.AutoSize = true;
            this.lblCurrentPageData.Location = new System.Drawing.Point(225, 102);
            this.lblCurrentPageData.Name = "lblCurrentPageData";
            this.lblCurrentPageData.Size = new System.Drawing.Size(27, 13);
            this.lblCurrentPageData.TabIndex = 9;
            this.lblCurrentPageData.Text = "N/A";
            // 
            // lblParsed
            // 
            this.lblParsed.AutoSize = true;
            this.lblParsed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParsed.Location = new System.Drawing.Point(292, 102);
            this.lblParsed.Name = "lblParsed";
            this.lblParsed.Size = new System.Drawing.Size(50, 13);
            this.lblParsed.TabIndex = 7;
            this.lblParsed.Text = "Parsed:";
            // 
            // lblTotalPages
            // 
            this.lblTotalPages.AutoSize = true;
            this.lblTotalPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPages.Location = new System.Drawing.Point(290, 70);
            this.lblTotalPages.Name = "lblTotalPages";
            this.lblTotalPages.Size = new System.Drawing.Size(79, 13);
            this.lblTotalPages.TabIndex = 6;
            this.lblTotalPages.Text = "Total Pages:";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPage.Location = new System.Drawing.Point(127, 102);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(85, 13);
            this.lblCurrentPage.TabIndex = 5;
            this.lblCurrentPage.Text = "Current Page:";
            // 
            // lblMembersData
            // 
            this.lblMembersData.AutoSize = true;
            this.lblMembersData.Location = new System.Drawing.Point(225, 70);
            this.lblMembersData.Name = "lblMembersData";
            this.lblMembersData.Size = new System.Drawing.Size(27, 13);
            this.lblMembersData.TabIndex = 4;
            this.lblMembersData.Text = "N/A";
            // 
            // lblMembers
            // 
            this.lblMembers.AutoSize = true;
            this.lblMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMembers.Location = new System.Drawing.Point(125, 70);
            this.lblMembers.Name = "lblMembers";
            this.lblMembers.Size = new System.Drawing.Size(94, 13);
            this.lblMembers.TabIndex = 3;
            this.lblMembers.Text = "Total Members:";
            // 
            // tGroupURLData
            // 
            this.tGroupURLData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tGroupURLData.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tGroupURLData.Location = new System.Drawing.Point(296, 22);
            this.tGroupURLData.Name = "tGroupURLData";
            this.tGroupURLData.Size = new System.Drawing.Size(100, 20);
            this.tGroupURLData.TabIndex = 2;
            // 
            // lblGroupURLPrefix
            // 
            this.lblGroupURLPrefix.AutoSize = true;
            this.lblGroupURLPrefix.Location = new System.Drawing.Point(119, 25);
            this.lblGroupURLPrefix.Name = "lblGroupURLPrefix";
            this.lblGroupURLPrefix.Size = new System.Drawing.Size(181, 13);
            this.lblGroupURLPrefix.TabIndex = 1;
            this.lblGroupURLPrefix.Text = "http://steamcommunity.com/groups/";
            // 
            // lblGroupURL
            // 
            this.lblGroupURL.AutoSize = true;
            this.lblGroupURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupURL.Location = new System.Drawing.Point(42, 25);
            this.lblGroupURL.Name = "lblGroupURL";
            this.lblGroupURL.Size = new System.Drawing.Size(74, 13);
            this.lblGroupURL.TabIndex = 0;
            this.lblGroupURL.Text = "Group URL:";
            // 
            // tabInviter
            // 
            this.tabInviter.Controls.Add(this.bSource);
            this.tabInviter.Controls.Add(this.tSource);
            this.tabInviter.Controls.Add(this.lblSource);
            this.tabInviter.Controls.Add(this.bLoginInviter);
            this.tabInviter.Controls.Add(this.bStartInviter);
            this.tabInviter.Controls.Add(this.gData);
            this.tabInviter.Location = new System.Drawing.Point(4, 22);
            this.tabInviter.Name = "tabInviter";
            this.tabInviter.Size = new System.Drawing.Size(452, 234);
            this.tabInviter.TabIndex = 1;
            this.tabInviter.Text = "Inviter";
            this.tabInviter.UseVisualStyleBackColor = true;
            // 
            // bSource
            // 
            this.bSource.Location = new System.Drawing.Point(315, 15);
            this.bSource.Name = "bSource";
            this.bSource.Size = new System.Drawing.Size(75, 23);
            this.bSource.TabIndex = 6;
            this.bSource.Text = "Open...";
            this.bSource.UseVisualStyleBackColor = true;
            this.bSource.Click += new System.EventHandler(this.bSource_Click);
            // 
            // tSource
            // 
            this.tSource.Enabled = false;
            this.tSource.Location = new System.Drawing.Point(159, 17);
            this.tSource.Name = "tSource";
            this.tSource.Size = new System.Drawing.Size(150, 20);
            this.tSource.TabIndex = 5;
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSource.Location = new System.Drawing.Point(90, 20);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(63, 13);
            this.lblSource.TabIndex = 4;
            this.lblSource.Text = "Load File:";
            this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bLoginInviter
            // 
            this.bLoginInviter.Location = new System.Drawing.Point(230, 170);
            this.bLoginInviter.Name = "bLoginInviter";
            this.bLoginInviter.Size = new System.Drawing.Size(200, 50);
            this.bLoginInviter.TabIndex = 4;
            this.bLoginInviter.Text = "Login";
            this.bLoginInviter.UseVisualStyleBackColor = true;
            this.bLoginInviter.Click += new System.EventHandler(this.bLoginInviter_Click);
            // 
            // bStartInviter
            // 
            this.bStartInviter.Enabled = false;
            this.bStartInviter.Location = new System.Drawing.Point(20, 170);
            this.bStartInviter.Name = "bStartInviter";
            this.bStartInviter.Size = new System.Drawing.Size(200, 50);
            this.bStartInviter.TabIndex = 3;
            this.bStartInviter.Text = "Start";
            this.bStartInviter.UseVisualStyleBackColor = true;
            this.bStartInviter.Click += new System.EventHandler(this.bStartInviter_Click);
            // 
            // gData
            // 
            this.gData.Controls.Add(this.tHistory);
            this.gData.Controls.Add(this.lblIntervalData);
            this.gData.Controls.Add(this.tInterval);
            this.gData.Controls.Add(this.tUsername);
            this.gData.Controls.Add(this.tPassword);
            this.gData.Controls.Add(this.lblInterval);
            this.gData.Controls.Add(this.lblPassword);
            this.gData.Controls.Add(this.lblUsername);
            this.gData.Location = new System.Drawing.Point(3, 48);
            this.gData.Name = "gData";
            this.gData.Size = new System.Drawing.Size(445, 110);
            this.gData.TabIndex = 0;
            this.gData.TabStop = false;
            this.gData.Text = "Invitation Settings";
            // 
            // lblIntervalData
            // 
            this.lblIntervalData.AutoSize = true;
            this.lblIntervalData.Location = new System.Drawing.Point(129, 80);
            this.lblIntervalData.Name = "lblIntervalData";
            this.lblIntervalData.Size = new System.Drawing.Size(49, 13);
            this.lblIntervalData.TabIndex = 7;
            this.lblIntervalData.Text = "Seconds";
            // 
            // tInterval
            // 
            this.tInterval.Location = new System.Drawing.Point(83, 77);
            this.tInterval.MaxLength = 3;
            this.tInterval.Name = "tInterval";
            this.tInterval.Size = new System.Drawing.Size(40, 20);
            this.tInterval.TabIndex = 6;
            // 
            // tUsername
            // 
            this.tUsername.Location = new System.Drawing.Point(83, 22);
            this.tUsername.Name = "tUsername";
            this.tUsername.Size = new System.Drawing.Size(120, 20);
            this.tUsername.TabIndex = 1;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(83, 47);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(120, 20);
            this.tPassword.TabIndex = 2;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterval.Location = new System.Drawing.Point(10, 80);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(54, 13);
            this.lblInterval.TabIndex = 3;
            this.lblInterval.Text = "Interval:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(10, 50);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(65, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(10, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(67, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username:";
            // 
            // ofSource
            // 
            this.ofSource.Filter = "Text-Dateien|*.txt|CSV-Dateien|*.csv";
            // 
            // tHistory
            // 
            this.tHistory.Location = new System.Drawing.Point(220, 22);
            this.tHistory.Name = "tHistory";
            this.tHistory.Size = new System.Drawing.Size(207, 71);
            this.tHistory.TabIndex = 8;
            this.tHistory.Text = "";
            // 
            // HarvesterGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 282);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HarvesterGUI";
            this.Text = "Steam Group Toolkit";
            this.tabMain.ResumeLayout(false);
            this.tabHarvester.ResumeLayout(false);
            this.gInformation.ResumeLayout(false);
            this.gInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pAvatar)).EndInit();
            this.tabInviter.ResumeLayout(false);
            this.tabInviter.PerformLayout();
            this.gData.ResumeLayout(false);
            this.gData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabHarvester;
        private System.Windows.Forms.TabPage tabInviter;
        private System.Windows.Forms.GroupBox gInformation;
        private System.Windows.Forms.Label lblGroupURL;
        private System.Windows.Forms.Label lblGroupURLPrefix;
        private System.Windows.Forms.TextBox tGroupURLData;
        private System.Windows.Forms.Label lblMembers;
        private System.Windows.Forms.Label lblMembersData;
        private System.Windows.Forms.Label lblTotalPagesData;
        private System.Windows.Forms.Label lblCurrentPageData;
        private System.Windows.Forms.Label lblParsed;
        private System.Windows.Forms.Label lblTotalPages;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblParsedData;
        private System.Windows.Forms.Button bStop;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.PictureBox pAvatar;
        private System.Windows.Forms.GroupBox gData;
        private System.Windows.Forms.Button bStartInviter;
        private System.Windows.Forms.Button bLoginInviter;
        private System.Windows.Forms.OpenFileDialog ofSource;
        private System.Windows.Forms.Button bSource;
        private System.Windows.Forms.TextBox tSource;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.TextBox tUsername;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox tInterval;
        private System.Windows.Forms.Label lblIntervalData;
        private System.Windows.Forms.RichTextBox tHistory;
    }
}