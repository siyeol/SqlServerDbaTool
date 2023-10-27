namespace HaTool.HighAvailability
{
    partial class UcTargetGroup
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonServerListReload = new System.Windows.Forms.Button();
            this.dgvServerList = new System.Windows.Forms.DataGridView();
            this.groupBoxMirroring = new System.Windows.Forms.GroupBox();
            this.groupBoxSqlServerConfigurationTemplate = new System.Windows.Forms.GroupBox();
            this.buttonCreateLoadBalancer = new System.Windows.Forms.Button();
            this.labelZone = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.comboBoxSubnet = new System.Windows.Forms.ComboBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLoadBalancerName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxTargetGroup = new System.Windows.Forms.GroupBox();
            this.buttonDeleteTargetGroup = new System.Windows.Forms.Button();
            this.buttonReloadTargetGroup = new System.Windows.Forms.Button();
            this.dgvTargetGroup = new System.Windows.Forms.DataGridView();
            this.groupBoxCreateTG = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTargetGroupName = new System.Windows.Forms.TextBox();
            this.labelCurrentAccessKey = new System.Windows.Forms.Label();
            this.comboBoxTargetGroupProtocol = new System.Windows.Forms.ComboBox();
            this.labelProtocol = new System.Windows.Forms.Label();
            this.buttonCreateTargetGroup = new System.Windows.Forms.Button();
            this.comboBoxVPC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSelectHaGroup = new System.Windows.Forms.GroupBox();
            this.buttonDeleteLoadBalancer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerList)).BeginInit();
            this.groupBoxMirroring.SuspendLayout();
            this.groupBoxSqlServerConfigurationTemplate.SuspendLayout();
            this.groupBoxTargetGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetGroup)).BeginInit();
            this.groupBoxCreateTG.SuspendLayout();
            this.groupBoxSelectHaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonServerListReload
            // 
            this.buttonServerListReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonServerListReload.Location = new System.Drawing.Point(20, 184);
            this.buttonServerListReload.Name = "buttonServerListReload";
            this.buttonServerListReload.Size = new System.Drawing.Size(107, 23);
            this.buttonServerListReload.TabIndex = 40;
            this.buttonServerListReload.Text = "Reload";
            this.buttonServerListReload.UseVisualStyleBackColor = true;
            // 
            // dgvServerList
            // 
            this.dgvServerList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvServerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServerList.Location = new System.Drawing.Point(20, 22);
            this.dgvServerList.Name = "dgvServerList";
            this.dgvServerList.RowHeadersWidth = 62;
            this.dgvServerList.Size = new System.Drawing.Size(705, 156);
            this.dgvServerList.TabIndex = 2;
            // 
            // groupBoxMirroring
            // 
            this.groupBoxMirroring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMirroring.AutoSize = true;
            this.groupBoxMirroring.Controls.Add(this.groupBoxSqlServerConfigurationTemplate);
            this.groupBoxMirroring.Controls.Add(this.groupBoxTargetGroup);
            this.groupBoxMirroring.Controls.Add(this.groupBoxCreateTG);
            this.groupBoxMirroring.Controls.Add(this.groupBoxSelectHaGroup);
            this.groupBoxMirroring.Location = new System.Drawing.Point(1, 3);
            this.groupBoxMirroring.Name = "groupBoxMirroring";
            this.groupBoxMirroring.Size = new System.Drawing.Size(770, 681);
            this.groupBoxMirroring.TabIndex = 2;
            this.groupBoxMirroring.TabStop = false;
            this.groupBoxMirroring.Text = "High Availability > Target Group";
            // 
            // groupBoxSqlServerConfigurationTemplate
            // 
            this.groupBoxSqlServerConfigurationTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonCreateLoadBalancer);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelZone);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxRegion);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxSubnet);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelRegion);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxProtocol);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.label4);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.textBoxLoadBalancerName);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.label5);
            this.groupBoxSqlServerConfigurationTemplate.Location = new System.Drawing.Point(22, 530);
            this.groupBoxSqlServerConfigurationTemplate.Name = "groupBoxSqlServerConfigurationTemplate";
            this.groupBoxSqlServerConfigurationTemplate.Size = new System.Drawing.Size(742, 109);
            this.groupBoxSqlServerConfigurationTemplate.TabIndex = 163;
            this.groupBoxSqlServerConfigurationTemplate.TabStop = false;
            this.groupBoxSqlServerConfigurationTemplate.Text = "Load Balancer Configuration Template";
            // 
            // buttonCreateLoadBalancer
            // 
            this.buttonCreateLoadBalancer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateLoadBalancer.Location = new System.Drawing.Point(20, 80);
            this.buttonCreateLoadBalancer.Name = "buttonCreateLoadBalancer";
            this.buttonCreateLoadBalancer.Size = new System.Drawing.Size(118, 23);
            this.buttonCreateLoadBalancer.TabIndex = 69;
            this.buttonCreateLoadBalancer.Text = "Create";
            this.buttonCreateLoadBalancer.UseVisualStyleBackColor = true;
            this.buttonCreateLoadBalancer.Click += new System.EventHandler(this.buttonCreateLoadBalancer_Click);
            // 
            // labelZone
            // 
            this.labelZone.AutoSize = true;
            this.labelZone.Location = new System.Drawing.Point(287, 27);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(49, 15);
            this.labelZone.TabIndex = 56;
            this.labelZone.Text = "Subnet";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(152, 45);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(123, 23);
            this.comboBoxRegion.TabIndex = 66;
            // 
            // comboBoxSubnet
            // 
            this.comboBoxSubnet.FormattingEnabled = true;
            this.comboBoxSubnet.Location = new System.Drawing.Point(283, 45);
            this.comboBoxSubnet.Name = "comboBoxSubnet";
            this.comboBoxSubnet.Size = new System.Drawing.Size(123, 23);
            this.comboBoxSubnet.TabIndex = 55;
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(157, 27);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(49, 15);
            this.labelRegion.TabIndex = 65;
            this.labelRegion.Text = "Region";
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBoxProtocol.Location = new System.Drawing.Point(413, 45);
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.Size = new System.Drawing.Size(123, 23);
            this.comboBoxProtocol.TabIndex = 60;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 54;
            this.label4.Text = "Protocol";
            // 
            // textBoxLoadBalancerName
            // 
            this.textBoxLoadBalancerName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLoadBalancerName.Location = new System.Drawing.Point(23, 45);
            this.textBoxLoadBalancerName.Name = "textBoxLoadBalancerName";
            this.textBoxLoadBalancerName.Size = new System.Drawing.Size(123, 23);
            this.textBoxLoadBalancerName.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 42;
            this.label5.Text = "Name";
            // 
            // groupBoxTargetGroup
            // 
            this.groupBoxTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTargetGroup.Controls.Add(this.buttonDeleteLoadBalancer);
            this.groupBoxTargetGroup.Controls.Add(this.buttonDeleteTargetGroup);
            this.groupBoxTargetGroup.Controls.Add(this.buttonReloadTargetGroup);
            this.groupBoxTargetGroup.Controls.Add(this.dgvTargetGroup);
            this.groupBoxTargetGroup.Location = new System.Drawing.Point(22, 341);
            this.groupBoxTargetGroup.Name = "groupBoxTargetGroup";
            this.groupBoxTargetGroup.Size = new System.Drawing.Size(742, 183);
            this.groupBoxTargetGroup.TabIndex = 160;
            this.groupBoxTargetGroup.TabStop = false;
            this.groupBoxTargetGroup.Text = "Target Group List";
            // 
            // buttonDeleteTargetGroup
            // 
            this.buttonDeleteTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteTargetGroup.Location = new System.Drawing.Point(132, 154);
            this.buttonDeleteTargetGroup.Name = "buttonDeleteTargetGroup";
            this.buttonDeleteTargetGroup.Size = new System.Drawing.Size(107, 23);
            this.buttonDeleteTargetGroup.TabIndex = 41;
            this.buttonDeleteTargetGroup.Text = "Delete";
            this.buttonDeleteTargetGroup.UseVisualStyleBackColor = true;
            this.buttonDeleteTargetGroup.Click += new System.EventHandler(this.buttonDeleteTargetGroup_Click);
            // 
            // buttonReloadTargetGroup
            // 
            this.buttonReloadTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReloadTargetGroup.Location = new System.Drawing.Point(19, 154);
            this.buttonReloadTargetGroup.Name = "buttonReloadTargetGroup";
            this.buttonReloadTargetGroup.Size = new System.Drawing.Size(107, 23);
            this.buttonReloadTargetGroup.TabIndex = 40;
            this.buttonReloadTargetGroup.Text = "Reload";
            this.buttonReloadTargetGroup.UseVisualStyleBackColor = true;
            this.buttonReloadTargetGroup.Click += new System.EventHandler(this.buttonReloadTargetGroup_Click);
            // 
            // dgvTargetGroup
            // 
            this.dgvTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTargetGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTargetGroup.Location = new System.Drawing.Point(20, 22);
            this.dgvTargetGroup.Name = "dgvTargetGroup";
            this.dgvTargetGroup.RowHeadersWidth = 62;
            this.dgvTargetGroup.Size = new System.Drawing.Size(705, 126);
            this.dgvTargetGroup.TabIndex = 2;
            // 
            // groupBoxCreateTG
            // 
            this.groupBoxCreateTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCreateTG.Controls.Add(this.textBoxPort);
            this.groupBoxCreateTG.Controls.Add(this.label6);
            this.groupBoxCreateTG.Controls.Add(this.textBoxTargetGroupName);
            this.groupBoxCreateTG.Controls.Add(this.labelCurrentAccessKey);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxTargetGroupProtocol);
            this.groupBoxCreateTG.Controls.Add(this.labelProtocol);
            this.groupBoxCreateTG.Controls.Add(this.buttonCreateTargetGroup);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxVPC);
            this.groupBoxCreateTG.Controls.Add(this.label1);
            this.groupBoxCreateTG.Location = new System.Drawing.Point(22, 241);
            this.groupBoxCreateTG.Name = "groupBoxCreateTG";
            this.groupBoxCreateTG.Size = new System.Drawing.Size(742, 94);
            this.groupBoxCreateTG.TabIndex = 162;
            this.groupBoxCreateTG.TabStop = false;
            this.groupBoxCreateTG.Text = "Create Target Group";
            // 
            // textBoxPort
            // 
            this.textBoxPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxPort.Location = new System.Drawing.Point(407, 39);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(123, 23);
            this.textBoxPort.TabIndex = 169;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 170;
            this.label6.Text = "Port";
            // 
            // textBoxTargetGroupName
            // 
            this.textBoxTargetGroupName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTargetGroupName.Location = new System.Drawing.Point(20, 39);
            this.textBoxTargetGroupName.Name = "textBoxTargetGroupName";
            this.textBoxTargetGroupName.Size = new System.Drawing.Size(123, 23);
            this.textBoxTargetGroupName.TabIndex = 167;
            // 
            // labelCurrentAccessKey
            // 
            this.labelCurrentAccessKey.AutoSize = true;
            this.labelCurrentAccessKey.Location = new System.Drawing.Point(23, 19);
            this.labelCurrentAccessKey.Name = "labelCurrentAccessKey";
            this.labelCurrentAccessKey.Size = new System.Drawing.Size(35, 15);
            this.labelCurrentAccessKey.TabIndex = 168;
            this.labelCurrentAccessKey.Text = "Name";
            // 
            // comboBoxTargetGroupProtocol
            // 
            this.comboBoxTargetGroupProtocol.FormattingEnabled = true;
            this.comboBoxTargetGroupProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBoxTargetGroupProtocol.Location = new System.Drawing.Point(278, 39);
            this.comboBoxTargetGroupProtocol.Name = "comboBoxTargetGroupProtocol";
            this.comboBoxTargetGroupProtocol.Size = new System.Drawing.Size(123, 23);
            this.comboBoxTargetGroupProtocol.TabIndex = 164;
            // 
            // labelProtocol
            // 
            this.labelProtocol.AutoSize = true;
            this.labelProtocol.Location = new System.Drawing.Point(281, 21);
            this.labelProtocol.Name = "labelProtocol";
            this.labelProtocol.Size = new System.Drawing.Size(63, 15);
            this.labelProtocol.TabIndex = 163;
            this.labelProtocol.Text = "Protocol";
            // 
            // buttonCreateTargetGroup
            // 
            this.buttonCreateTargetGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCreateTargetGroup.Location = new System.Drawing.Point(20, 65);
            this.buttonCreateTargetGroup.Name = "buttonCreateTargetGroup";
            this.buttonCreateTargetGroup.Size = new System.Drawing.Size(118, 23);
            this.buttonCreateTargetGroup.TabIndex = 162;
            this.buttonCreateTargetGroup.Text = "Create";
            this.buttonCreateTargetGroup.UseVisualStyleBackColor = true;
            this.buttonCreateTargetGroup.Click += new System.EventHandler(this.buttonCreateTargetGroup_ClickAsync);
            // 
            // comboBoxVPC
            // 
            this.comboBoxVPC.FormattingEnabled = true;
            this.comboBoxVPC.Location = new System.Drawing.Point(149, 39);
            this.comboBoxVPC.Name = "comboBoxVPC";
            this.comboBoxVPC.Size = new System.Drawing.Size(123, 23);
            this.comboBoxVPC.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 161;
            this.label1.Text = "VPC";
            // 
            // groupBoxSelectHaGroup
            // 
            this.groupBoxSelectHaGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSelectHaGroup.Controls.Add(this.buttonServerListReload);
            this.groupBoxSelectHaGroup.Controls.Add(this.dgvServerList);
            this.groupBoxSelectHaGroup.Location = new System.Drawing.Point(22, 22);
            this.groupBoxSelectHaGroup.Name = "groupBoxSelectHaGroup";
            this.groupBoxSelectHaGroup.Size = new System.Drawing.Size(742, 213);
            this.groupBoxSelectHaGroup.TabIndex = 159;
            this.groupBoxSelectHaGroup.TabStop = false;
            this.groupBoxSelectHaGroup.Text = "Select Server";
            // 
            // buttonDeleteLoadBalancer
            // 
            this.buttonDeleteLoadBalancer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteLoadBalancer.Location = new System.Drawing.Point(245, 154);
            this.buttonDeleteLoadBalancer.Name = "buttonDeleteLoadBalancer";
            this.buttonDeleteLoadBalancer.Size = new System.Drawing.Size(107, 23);
            this.buttonDeleteLoadBalancer.TabIndex = 42;
            this.buttonDeleteLoadBalancer.Text = "Disconnect";
            this.buttonDeleteLoadBalancer.UseVisualStyleBackColor = true;
            this.buttonDeleteLoadBalancer.Click += new System.EventHandler(this.buttonDeleteLoadBalancer_Click);
            // 
            // UcTargetGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxMirroring);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Name = "UcTargetGroup";
            this.Size = new System.Drawing.Size(776, 688);
            this.Load += new System.EventHandler(this.LoadData);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerList)).EndInit();
            this.groupBoxMirroring.ResumeLayout(false);
            this.groupBoxSqlServerConfigurationTemplate.ResumeLayout(false);
            this.groupBoxSqlServerConfigurationTemplate.PerformLayout();
            this.groupBoxTargetGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetGroup)).EndInit();
            this.groupBoxCreateTG.ResumeLayout(false);
            this.groupBoxCreateTG.PerformLayout();
            this.groupBoxSelectHaGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonServerListReload;
        private System.Windows.Forms.DataGridView dgvServerList;
        private System.Windows.Forms.GroupBox groupBoxMirroring;
        private System.Windows.Forms.GroupBox groupBoxSelectHaGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVPC;
        private System.Windows.Forms.GroupBox groupBoxCreateTG;
        private System.Windows.Forms.Button buttonCreateTargetGroup;
        private System.Windows.Forms.ComboBox comboBoxTargetGroupProtocol;
        private System.Windows.Forms.Label labelProtocol;
        private System.Windows.Forms.TextBox textBoxTargetGroupName;
        private System.Windows.Forms.Label labelCurrentAccessKey;
        private System.Windows.Forms.GroupBox groupBoxTargetGroup;
        private System.Windows.Forms.Button buttonReloadTargetGroup;
        private System.Windows.Forms.DataGridView dgvTargetGroup;
        private System.Windows.Forms.Button buttonDeleteTargetGroup;
        private System.Windows.Forms.GroupBox groupBoxSqlServerConfigurationTemplate;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.ComboBox comboBoxSubnet;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLoadBalancerName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCreateLoadBalancer;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonDeleteLoadBalancer;
    }
}
