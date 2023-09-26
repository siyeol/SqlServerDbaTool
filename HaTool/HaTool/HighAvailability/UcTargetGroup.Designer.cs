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
            this.buttonShowCheckedLBDetailInfo = new System.Windows.Forms.Button();
            this.buttonLoadBalancerNameCheck = new System.Windows.Forms.Button();
            this.buttonDbDelete = new System.Windows.Forms.Button();
            this.labelZone = new System.Windows.Forms.Label();
            this.comboBoxRegion = new System.Windows.Forms.ComboBox();
            this.comboBoxSubnet = new System.Windows.Forms.ComboBox();
            this.labelRegion = new System.Windows.Forms.Label();
            this.buttonDbSave = new System.Windows.Forms.Button();
            this.comboBoxProtocol = new System.Windows.Forms.ComboBox();
            this.buttonLoadTemplate = new System.Windows.Forms.Button();
            this.textBoxServerPort = new System.Windows.Forms.TextBox();
            this.buttonSaveTemplate = new System.Windows.Forms.Button();
            this.labelServerPort = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLoadBalancerName = new System.Windows.Forms.TextBox();
            this.textBoxLoadBalancerPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelLoadBalancerPort = new System.Windows.Forms.Label();
            this.groupBoxTargetGroup = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonReloadTargetGroup = new System.Windows.Forms.Button();
            this.dgvTargetGroup = new System.Windows.Forms.DataGridView();
            this.groupBoxCreateTG = new System.Windows.Forms.GroupBox();
            this.textBoxTGPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTargetGroupName = new System.Windows.Forms.TextBox();
            this.labelCurrentAccessKey = new System.Windows.Forms.Label();
            this.comboBoxHealthCheckProtocol = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTargetGroupProtocol = new System.Windows.Forms.ComboBox();
            this.labelProtocol = new System.Windows.Forms.Label();
            this.buttonCreateTargetGroup = new System.Windows.Forms.Button();
            this.comboBoxVPC = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSelectHaGroup = new System.Windows.Forms.GroupBox();
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
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonShowCheckedLBDetailInfo);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonLoadBalancerNameCheck);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonDbDelete);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelZone);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxRegion);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxSubnet);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelRegion);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonDbSave);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.comboBoxProtocol);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonLoadTemplate);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.textBoxServerPort);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.buttonSaveTemplate);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelServerPort);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.label4);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.textBoxLoadBalancerName);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.textBoxLoadBalancerPort);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.label5);
            this.groupBoxSqlServerConfigurationTemplate.Controls.Add(this.labelLoadBalancerPort);
            this.groupBoxSqlServerConfigurationTemplate.Location = new System.Drawing.Point(22, 543);
            this.groupBoxSqlServerConfigurationTemplate.Name = "groupBoxSqlServerConfigurationTemplate";
            this.groupBoxSqlServerConfigurationTemplate.Size = new System.Drawing.Size(742, 109);
            this.groupBoxSqlServerConfigurationTemplate.TabIndex = 163;
            this.groupBoxSqlServerConfigurationTemplate.TabStop = false;
            this.groupBoxSqlServerConfigurationTemplate.Text = "Load Balancer Configuration Template";
            // 
            // buttonCreateLoadBalancer
            // 
            this.buttonCreateLoadBalancer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateLoadBalancer.Location = new System.Drawing.Point(683, 74);
            this.buttonCreateLoadBalancer.Name = "buttonCreateLoadBalancer";
            this.buttonCreateLoadBalancer.Size = new System.Drawing.Size(118, 23);
            this.buttonCreateLoadBalancer.TabIndex = 69;
            this.buttonCreateLoadBalancer.Text = "Create";
            this.buttonCreateLoadBalancer.UseVisualStyleBackColor = true;
            this.buttonCreateLoadBalancer.Click += new System.EventHandler(this.buttonCreateLoadBalancer_Click);
            // 
            // buttonShowCheckedLBDetailInfo
            // 
            this.buttonShowCheckedLBDetailInfo.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonShowCheckedLBDetailInfo.Location = new System.Drawing.Point(384, 74);
            this.buttonShowCheckedLBDetailInfo.Name = "buttonShowCheckedLBDetailInfo";
            this.buttonShowCheckedLBDetailInfo.Size = new System.Drawing.Size(118, 23);
            this.buttonShowCheckedLBDetailInfo.TabIndex = 68;
            this.buttonShowCheckedLBDetailInfo.Text = "Show Detail";
            this.buttonShowCheckedLBDetailInfo.UseVisualStyleBackColor = true;
            // 
            // buttonLoadBalancerNameCheck
            // 
            this.buttonLoadBalancerNameCheck.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonLoadBalancerNameCheck.Location = new System.Drawing.Point(262, 74);
            this.buttonLoadBalancerNameCheck.Name = "buttonLoadBalancerNameCheck";
            this.buttonLoadBalancerNameCheck.Size = new System.Drawing.Size(118, 23);
            this.buttonLoadBalancerNameCheck.TabIndex = 67;
            this.buttonLoadBalancerNameCheck.Text = "Exists Check";
            this.buttonLoadBalancerNameCheck.UseVisualStyleBackColor = true;
            // 
            // buttonDbDelete
            // 
            this.buttonDbDelete.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonDbDelete.Location = new System.Drawing.Point(593, 74);
            this.buttonDbDelete.Name = "buttonDbDelete";
            this.buttonDbDelete.Size = new System.Drawing.Size(84, 23);
            this.buttonDbDelete.TabIndex = 58;
            this.buttonDbDelete.Text = "db delete";
            this.buttonDbDelete.UseVisualStyleBackColor = true;
            // 
            // labelZone
            // 
            this.labelZone.AutoSize = true;
            this.labelZone.Location = new System.Drawing.Point(287, 27);
            this.labelZone.Name = "labelZone";
            this.labelZone.Size = new System.Drawing.Size(76, 23);
            this.labelZone.TabIndex = 56;
            this.labelZone.Text = "Subnet";
            // 
            // comboBoxRegion
            // 
            this.comboBoxRegion.FormattingEnabled = true;
            this.comboBoxRegion.Location = new System.Drawing.Point(152, 45);
            this.comboBoxRegion.Name = "comboBoxRegion";
            this.comboBoxRegion.Size = new System.Drawing.Size(123, 31);
            this.comboBoxRegion.TabIndex = 66;
            // 
            // comboBoxSubnet
            // 
            this.comboBoxSubnet.FormattingEnabled = true;
            this.comboBoxSubnet.Location = new System.Drawing.Point(283, 45);
            this.comboBoxSubnet.Name = "comboBoxSubnet";
            this.comboBoxSubnet.Size = new System.Drawing.Size(123, 31);
            this.comboBoxSubnet.TabIndex = 55;
            // 
            // labelRegion
            // 
            this.labelRegion.AutoSize = true;
            this.labelRegion.Location = new System.Drawing.Point(157, 27);
            this.labelRegion.Name = "labelRegion";
            this.labelRegion.Size = new System.Drawing.Size(76, 23);
            this.labelRegion.TabIndex = 65;
            this.labelRegion.Text = "Region";
            // 
            // buttonDbSave
            // 
            this.buttonDbSave.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.buttonDbSave.Location = new System.Drawing.Point(507, 74);
            this.buttonDbSave.Name = "buttonDbSave";
            this.buttonDbSave.Size = new System.Drawing.Size(84, 23);
            this.buttonDbSave.TabIndex = 57;
            this.buttonDbSave.Text = "db save";
            this.buttonDbSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxProtocol
            // 
            this.comboBoxProtocol.FormattingEnabled = true;
            this.comboBoxProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBoxProtocol.Location = new System.Drawing.Point(413, 45);
            this.comboBoxProtocol.Name = "comboBoxProtocol";
            this.comboBoxProtocol.Size = new System.Drawing.Size(123, 31);
            this.comboBoxProtocol.TabIndex = 60;
            // 
            // buttonLoadTemplate
            // 
            this.buttonLoadTemplate.Location = new System.Drawing.Point(141, 74);
            this.buttonLoadTemplate.Name = "buttonLoadTemplate";
            this.buttonLoadTemplate.Size = new System.Drawing.Size(118, 23);
            this.buttonLoadTemplate.TabIndex = 54;
            this.buttonLoadTemplate.Text = "Load Template";
            this.buttonLoadTemplate.UseVisualStyleBackColor = true;
            // 
            // textBoxServerPort
            // 
            this.textBoxServerPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxServerPort.Location = new System.Drawing.Point(674, 45);
            this.textBoxServerPort.Name = "textBoxServerPort";
            this.textBoxServerPort.Size = new System.Drawing.Size(123, 30);
            this.textBoxServerPort.TabIndex = 58;
            // 
            // buttonSaveTemplate
            // 
            this.buttonSaveTemplate.Location = new System.Drawing.Point(22, 74);
            this.buttonSaveTemplate.Name = "buttonSaveTemplate";
            this.buttonSaveTemplate.Size = new System.Drawing.Size(118, 23);
            this.buttonSaveTemplate.TabIndex = 53;
            this.buttonSaveTemplate.Text = "Save Template";
            this.buttonSaveTemplate.UseVisualStyleBackColor = true;
            // 
            // labelServerPort
            // 
            this.labelServerPort.AutoSize = true;
            this.labelServerPort.Location = new System.Drawing.Point(677, 27);
            this.labelServerPort.Name = "labelServerPort";
            this.labelServerPort.Size = new System.Drawing.Size(131, 23);
            this.labelServerPort.TabIndex = 59;
            this.labelServerPort.Text = "Server Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 23);
            this.label4.TabIndex = 54;
            this.label4.Text = "Protocol";
            // 
            // textBoxLoadBalancerName
            // 
            this.textBoxLoadBalancerName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLoadBalancerName.Location = new System.Drawing.Point(23, 45);
            this.textBoxLoadBalancerName.Name = "textBoxLoadBalancerName";
            this.textBoxLoadBalancerName.Size = new System.Drawing.Size(123, 30);
            this.textBoxLoadBalancerName.TabIndex = 40;
            // 
            // textBoxLoadBalancerPort
            // 
            this.textBoxLoadBalancerPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxLoadBalancerPort.Location = new System.Drawing.Point(544, 45);
            this.textBoxLoadBalancerPort.Name = "textBoxLoadBalancerPort";
            this.textBoxLoadBalancerPort.Size = new System.Drawing.Size(123, 30);
            this.textBoxLoadBalancerPort.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 23);
            this.label5.TabIndex = 42;
            this.label5.Text = "Name";
            // 
            // labelLoadBalancerPort
            // 
            this.labelLoadBalancerPort.AutoSize = true;
            this.labelLoadBalancerPort.Location = new System.Drawing.Point(544, 27);
            this.labelLoadBalancerPort.Name = "labelLoadBalancerPort";
            this.labelLoadBalancerPort.Size = new System.Drawing.Size(208, 23);
            this.labelLoadBalancerPort.TabIndex = 43;
            this.labelLoadBalancerPort.Text = "Load Balancer Port";
            // 
            // groupBoxTargetGroup
            // 
            this.groupBoxTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTargetGroup.Controls.Add(this.buttonDelete);
            this.groupBoxTargetGroup.Controls.Add(this.buttonReloadTargetGroup);
            this.groupBoxTargetGroup.Controls.Add(this.dgvTargetGroup);
            this.groupBoxTargetGroup.Location = new System.Drawing.Point(22, 354);
            this.groupBoxTargetGroup.Name = "groupBoxTargetGroup";
            this.groupBoxTargetGroup.Size = new System.Drawing.Size(742, 183);
            this.groupBoxTargetGroup.TabIndex = 160;
            this.groupBoxTargetGroup.TabStop = false;
            this.groupBoxTargetGroup.Text = "Target Group List";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDelete.Location = new System.Drawing.Point(132, 154);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 23);
            this.buttonDelete.TabIndex = 41;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
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
            this.groupBoxCreateTG.Controls.Add(this.textBoxTGPort);
            this.groupBoxCreateTG.Controls.Add(this.label6);
            this.groupBoxCreateTG.Controls.Add(this.textBoxTargetGroupName);
            this.groupBoxCreateTG.Controls.Add(this.labelCurrentAccessKey);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxHealthCheckProtocol);
            this.groupBoxCreateTG.Controls.Add(this.label2);
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
            // textBoxTGPort
            // 
            this.textBoxTGPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTGPort.Location = new System.Drawing.Point(522, 44);
            this.textBoxTGPort.Name = "textBoxTGPort";
            this.textBoxTGPort.Size = new System.Drawing.Size(123, 30);
            this.textBoxTGPort.TabIndex = 169;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(525, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 23);
            this.label6.TabIndex = 170;
            this.label6.Text = "Port";
            // 
            // textBoxTargetGroupName
            // 
            this.textBoxTargetGroupName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxTargetGroupName.Location = new System.Drawing.Point(6, 44);
            this.textBoxTargetGroupName.Name = "textBoxTargetGroupName";
            this.textBoxTargetGroupName.Size = new System.Drawing.Size(123, 30);
            this.textBoxTargetGroupName.TabIndex = 167;
            // 
            // labelCurrentAccessKey
            // 
            this.labelCurrentAccessKey.AutoSize = true;
            this.labelCurrentAccessKey.Location = new System.Drawing.Point(9, 24);
            this.labelCurrentAccessKey.Name = "labelCurrentAccessKey";
            this.labelCurrentAccessKey.Size = new System.Drawing.Size(54, 23);
            this.labelCurrentAccessKey.TabIndex = 168;
            this.labelCurrentAccessKey.Text = "Name";
            // 
            // comboBoxHealthCheckProtocol
            // 
            this.comboBoxHealthCheckProtocol.FormattingEnabled = true;
            this.comboBoxHealthCheckProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBoxHealthCheckProtocol.Location = new System.Drawing.Point(393, 44);
            this.comboBoxHealthCheckProtocol.Name = "comboBoxHealthCheckProtocol";
            this.comboBoxHealthCheckProtocol.Size = new System.Drawing.Size(123, 31);
            this.comboBoxHealthCheckProtocol.TabIndex = 166;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(396, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 23);
            this.label2.TabIndex = 165;
            this.label2.Text = "Health Check Protocol";
            // 
            // comboBoxTargetGroupProtocol
            // 
            this.comboBoxTargetGroupProtocol.FormattingEnabled = true;
            this.comboBoxTargetGroupProtocol.Items.AddRange(new object[] {
            "TCP",
            "UDP"});
            this.comboBoxTargetGroupProtocol.Location = new System.Drawing.Point(264, 44);
            this.comboBoxTargetGroupProtocol.Name = "comboBoxTargetGroupProtocol";
            this.comboBoxTargetGroupProtocol.Size = new System.Drawing.Size(123, 31);
            this.comboBoxTargetGroupProtocol.TabIndex = 164;
            // 
            // labelProtocol
            // 
            this.labelProtocol.AutoSize = true;
            this.labelProtocol.Location = new System.Drawing.Point(267, 26);
            this.labelProtocol.Name = "labelProtocol";
            this.labelProtocol.Size = new System.Drawing.Size(241, 23);
            this.labelProtocol.TabIndex = 163;
            this.labelProtocol.Text = "Target Group Protocol";
            // 
            // buttonCreateTargetGroup
            // 
            this.buttonCreateTargetGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonCreateTargetGroup.Location = new System.Drawing.Point(6, 70);
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
            this.comboBoxVPC.Location = new System.Drawing.Point(135, 44);
            this.comboBoxVPC.Name = "comboBoxVPC";
            this.comboBoxVPC.Size = new System.Drawing.Size(123, 31);
            this.comboBoxVPC.TabIndex = 160;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 23);
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
        private System.Windows.Forms.ComboBox comboBoxHealthCheckProtocol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTargetGroupName;
        private System.Windows.Forms.Label labelCurrentAccessKey;
        private System.Windows.Forms.GroupBox groupBoxTargetGroup;
        private System.Windows.Forms.Button buttonReloadTargetGroup;
        private System.Windows.Forms.DataGridView dgvTargetGroup;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.GroupBox groupBoxSqlServerConfigurationTemplate;
        private System.Windows.Forms.Button buttonShowCheckedLBDetailInfo;
        private System.Windows.Forms.Button buttonLoadBalancerNameCheck;
        private System.Windows.Forms.Button buttonDbDelete;
        private System.Windows.Forms.Label labelZone;
        private System.Windows.Forms.ComboBox comboBoxRegion;
        private System.Windows.Forms.ComboBox comboBoxSubnet;
        private System.Windows.Forms.Label labelRegion;
        private System.Windows.Forms.Button buttonDbSave;
        private System.Windows.Forms.ComboBox comboBoxProtocol;
        private System.Windows.Forms.Button buttonLoadTemplate;
        private System.Windows.Forms.TextBox textBoxServerPort;
        private System.Windows.Forms.Button buttonSaveTemplate;
        private System.Windows.Forms.Label labelServerPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxLoadBalancerName;
        private System.Windows.Forms.TextBox textBoxLoadBalancerPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelLoadBalancerPort;
        private System.Windows.Forms.Button buttonCreateLoadBalancer;
        private System.Windows.Forms.TextBox textBoxTGPort;
        private System.Windows.Forms.Label label6;
    }
}
