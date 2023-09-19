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
            this.groupBoxTargetGroup = new System.Windows.Forms.GroupBox();
            this.buttonReloadTargetGroup = new System.Windows.Forms.Button();
            this.dgvTargetGroup = new System.Windows.Forms.DataGridView();
            this.groupBoxCreateTG = new System.Windows.Forms.GroupBox();
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
            this.buttonDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerList)).BeginInit();
            this.groupBoxMirroring.SuspendLayout();
            this.groupBoxTargetGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetGroup)).BeginInit();
            this.groupBoxCreateTG.SuspendLayout();
            this.groupBoxSelectHaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonServerListReload
            // 
            this.buttonServerListReload.Location = new System.Drawing.Point(20, 226);
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
            this.dgvServerList.Size = new System.Drawing.Size(705, 177);
            this.dgvServerList.TabIndex = 2;
            // 
            // groupBoxMirroring
            // 
            this.groupBoxMirroring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMirroring.Controls.Add(this.groupBoxTargetGroup);
            this.groupBoxMirroring.Controls.Add(this.groupBoxCreateTG);
            this.groupBoxMirroring.Controls.Add(this.groupBoxSelectHaGroup);
            this.groupBoxMirroring.Location = new System.Drawing.Point(1, 3);
            this.groupBoxMirroring.Name = "groupBoxMirroring";
            this.groupBoxMirroring.Size = new System.Drawing.Size(770, 694);
            this.groupBoxMirroring.TabIndex = 2;
            this.groupBoxMirroring.TabStop = false;
            this.groupBoxMirroring.Text = "High Availability > Target Group";
            // 
            // groupBoxTargetGroup
            // 
            this.groupBoxTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTargetGroup.Controls.Add(this.buttonDelete);
            this.groupBoxTargetGroup.Controls.Add(this.buttonReloadTargetGroup);
            this.groupBoxTargetGroup.Controls.Add(this.dgvTargetGroup);
            this.groupBoxTargetGroup.Location = new System.Drawing.Point(22, 399);
            this.groupBoxTargetGroup.Name = "groupBoxTargetGroup";
            this.groupBoxTargetGroup.Size = new System.Drawing.Size(742, 254);
            this.groupBoxTargetGroup.TabIndex = 160;
            this.groupBoxTargetGroup.TabStop = false;
            this.groupBoxTargetGroup.Text = "Target Group List";
            // 
            // buttonReloadTargetGroup
            // 
            this.buttonReloadTargetGroup.Location = new System.Drawing.Point(20, 223);
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
            this.dgvTargetGroup.Size = new System.Drawing.Size(705, 180);
            this.dgvTargetGroup.TabIndex = 2;
            // 
            // groupBoxCreateTG
            // 
            this.groupBoxCreateTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCreateTG.Controls.Add(this.textBoxTargetGroupName);
            this.groupBoxCreateTG.Controls.Add(this.labelCurrentAccessKey);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxHealthCheckProtocol);
            this.groupBoxCreateTG.Controls.Add(this.label2);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxTargetGroupProtocol);
            this.groupBoxCreateTG.Controls.Add(this.labelProtocol);
            this.groupBoxCreateTG.Controls.Add(this.buttonCreateTargetGroup);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxVPC);
            this.groupBoxCreateTG.Controls.Add(this.label1);
            this.groupBoxCreateTG.Location = new System.Drawing.Point(22, 286);
            this.groupBoxCreateTG.Name = "groupBoxCreateTG";
            this.groupBoxCreateTG.Size = new System.Drawing.Size(742, 104);
            this.groupBoxCreateTG.TabIndex = 162;
            this.groupBoxCreateTG.TabStop = false;
            this.groupBoxCreateTG.Text = "Create Target Group";
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
            this.buttonCreateTargetGroup.Location = new System.Drawing.Point(6, 84);
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
            this.groupBoxSelectHaGroup.Size = new System.Drawing.Size(742, 254);
            this.groupBoxSelectHaGroup.TabIndex = 159;
            this.groupBoxSelectHaGroup.TabStop = false;
            this.groupBoxSelectHaGroup.Text = "Select Server";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(133, 223);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 23);
            this.buttonDelete.TabIndex = 41;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // UcTargetGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxMirroring);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Name = "UcTargetGroup";
            this.Size = new System.Drawing.Size(776, 700);
            this.Load += new System.EventHandler(this.LoadData);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerList)).EndInit();
            this.groupBoxMirroring.ResumeLayout(false);
            this.groupBoxTargetGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTargetGroup)).EndInit();
            this.groupBoxCreateTG.ResumeLayout(false);
            this.groupBoxCreateTG.PerformLayout();
            this.groupBoxSelectHaGroup.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
