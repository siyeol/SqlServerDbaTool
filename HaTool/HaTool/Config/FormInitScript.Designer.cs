namespace HaTool.Config
{
    partial class FormInitScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInitScript));
            this.groupBoxOuter = new System.Windows.Forms.GroupBox();
            this.labelTextBoxRemoteKeyServerUrl = new System.Windows.Forms.Label();
            this.labelTextBoxLocalKey = new System.Windows.Forms.Label();
            this.textBoxPowerShellScriptName = new System.Windows.Forms.TextBox();
            this.textBoxAgentFolder = new System.Windows.Forms.TextBox();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.labelTextBoxInitScriptName = new System.Windows.Forms.Label();
            this.textBoxInitScriptName = new System.Windows.Forms.TextBox();
            this.groupBoxOuter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOuter
            // 
            this.groupBoxOuter.Controls.Add(this.labelTextBoxRemoteKeyServerUrl);
            this.groupBoxOuter.Controls.Add(this.labelTextBoxLocalKey);
            this.groupBoxOuter.Controls.Add(this.textBoxPowerShellScriptName);
            this.groupBoxOuter.Controls.Add(this.textBoxAgentFolder);
            this.groupBoxOuter.Location = new System.Drawing.Point(7, 7);
            this.groupBoxOuter.Name = "groupBoxOuter";
            this.groupBoxOuter.Size = new System.Drawing.Size(470, 202);
            this.groupBoxOuter.TabIndex = 0;
            this.groupBoxOuter.TabStop = false;
            this.groupBoxOuter.Text = "Config > Init Script Setting";
            // 
            // labelTextBoxRemoteKeyServerUrl
            // 
            this.labelTextBoxRemoteKeyServerUrl.AutoSize = true;
            this.labelTextBoxRemoteKeyServerUrl.Location = new System.Drawing.Point(19, 80);
            this.labelTextBoxRemoteKeyServerUrl.Name = "labelTextBoxRemoteKeyServerUrl";
            this.labelTextBoxRemoteKeyServerUrl.Size = new System.Drawing.Size(329, 23);
            this.labelTextBoxRemoteKeyServerUrl.TabIndex = 5;
            this.labelTextBoxRemoteKeyServerUrl.Text = "PowerShell Remote Script Name";
            // 
            // labelTextBoxLocalKey
            // 
            this.labelTextBoxLocalKey.AutoSize = true;
            this.labelTextBoxLocalKey.Location = new System.Drawing.Point(20, 27);
            this.labelTextBoxLocalKey.Name = "labelTextBoxLocalKey";
            this.labelTextBoxLocalKey.Size = new System.Drawing.Size(142, 23);
            this.labelTextBoxLocalKey.TabIndex = 4;
            this.labelTextBoxLocalKey.Text = "Agent Folder";
            // 
            // textBoxPowerShellScriptName
            // 
            this.textBoxPowerShellScriptName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPowerShellScriptName.Location = new System.Drawing.Point(16, 101);
            this.textBoxPowerShellScriptName.Name = "textBoxPowerShellScriptName";
            this.textBoxPowerShellScriptName.Size = new System.Drawing.Size(434, 30);
            this.textBoxPowerShellScriptName.TabIndex = 3;
            this.textBoxPowerShellScriptName.TextChanged += new System.EventHandler(this.TemplateChanged);
            // 
            // textBoxAgentFolder
            // 
            this.textBoxAgentFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxAgentFolder.Location = new System.Drawing.Point(16, 48);
            this.textBoxAgentFolder.Name = "textBoxAgentFolder";
            this.textBoxAgentFolder.Size = new System.Drawing.Size(434, 30);
            this.textBoxAgentFolder.TabIndex = 2;
            this.textBoxAgentFolder.TextChanged += new System.EventHandler(this.TemplateChanged);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(23, 282);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(98, 23);
            this.buttonUpload.TabIndex = 8;
            this.buttonUpload.Text = "Upload";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonVerify
            // 
            this.buttonVerify.Location = new System.Drawing.Point(231, 282);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(98, 23);
            this.buttonVerify.TabIndex = 7;
            this.buttonVerify.Text = "Verify";
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // textBoxComment
            // 
            this.textBoxComment.Location = new System.Drawing.Point(23, 215);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(435, 48);
            this.textBoxComment.TabIndex = 10;
            this.textBoxComment.Text = "Write the name of the server init script and the name of the PowerShell script. Y" +
    "ou do not need to change it, and you only need to upload once.";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(335, 282);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(98, 23);
            this.buttonClose.TabIndex = 11;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(127, 282);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(98, 23);
            this.buttonCreate.TabIndex = 12;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // labelTextBoxInitScriptName
            // 
            this.labelTextBoxInitScriptName.AutoSize = true;
            this.labelTextBoxInitScriptName.Location = new System.Drawing.Point(26, 141);
            this.labelTextBoxInitScriptName.Name = "labelTextBoxInitScriptName";
            this.labelTextBoxInitScriptName.Size = new System.Drawing.Size(186, 23);
            this.labelTextBoxInitScriptName.TabIndex = 7;
            this.labelTextBoxInitScriptName.Text = "Init Script Name";
            // 
            // textBoxInitScriptName
            // 
            this.textBoxInitScriptName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxInitScriptName.Location = new System.Drawing.Point(23, 162);
            this.textBoxInitScriptName.Name = "textBoxInitScriptName";
            this.textBoxInitScriptName.Size = new System.Drawing.Size(434, 30);
            this.textBoxInitScriptName.TabIndex = 6;
            // 
            // FormInitScript
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 317);
            this.Controls.Add(this.labelTextBoxInitScriptName);
            this.Controls.Add(this.textBoxInitScriptName);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.textBoxComment);
            this.Controls.Add(this.buttonVerify);
            this.Controls.Add(this.buttonUpload);
            this.Controls.Add(this.groupBoxOuter);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInitScript";
            this.Text = "Init Script";
            this.Load += new System.EventHandler(this.LoadData);
            this.groupBoxOuter.ResumeLayout(false);
            this.groupBoxOuter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOuter;
        private System.Windows.Forms.TextBox textBoxPowerShellScriptName;
        private System.Windows.Forms.TextBox textBoxAgentFolder;
        private System.Windows.Forms.Label labelTextBoxRemoteKeyServerUrl;
        private System.Windows.Forms.Label labelTextBoxLocalKey;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.TextBox textBoxComment;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Label labelTextBoxInitScriptName;
        private System.Windows.Forms.TextBox textBoxInitScriptName;
    }
}