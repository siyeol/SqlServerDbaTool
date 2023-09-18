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
            this.groupBoxSelectHaGroup = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVPC = new System.Windows.Forms.ComboBox();
            this.groupBoxCreateTG = new System.Windows.Forms.GroupBox();
            this.buttonCreateTargetGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServerList)).BeginInit();
            this.groupBoxMirroring.SuspendLayout();
            this.groupBoxSelectHaGroup.SuspendLayout();
            this.groupBoxCreateTG.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonServerListReload
            // 
            this.buttonServerListReload.Location = new System.Drawing.Point(20, 239);
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
            this.dgvServerList.Size = new System.Drawing.Size(705, 212);
            this.dgvServerList.TabIndex = 2;
            // 
            // groupBoxMirroring
            // 
            this.groupBoxMirroring.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxMirroring.Controls.Add(this.groupBoxCreateTG);
            this.groupBoxMirroring.Controls.Add(this.groupBoxSelectHaGroup);
            this.groupBoxMirroring.Location = new System.Drawing.Point(1, 3);
            this.groupBoxMirroring.Name = "groupBoxMirroring";
            this.groupBoxMirroring.Size = new System.Drawing.Size(770, 694);
            this.groupBoxMirroring.TabIndex = 2;
            this.groupBoxMirroring.TabStop = false;
            this.groupBoxMirroring.Text = "High Availability > Target Group";
            // 
            // groupBoxSelectHaGroup
            // 
            this.groupBoxSelectHaGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSelectHaGroup.Controls.Add(this.buttonServerListReload);
            this.groupBoxSelectHaGroup.Controls.Add(this.dgvServerList);
            this.groupBoxSelectHaGroup.Location = new System.Drawing.Point(22, 22);
            this.groupBoxSelectHaGroup.Name = "groupBoxSelectHaGroup";
            this.groupBoxSelectHaGroup.Size = new System.Drawing.Size(742, 281);
            this.groupBoxSelectHaGroup.TabIndex = 159;
            this.groupBoxSelectHaGroup.TabStop = false;
            this.groupBoxSelectHaGroup.Text = "Select Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 23);
            this.label1.TabIndex = 161;
            this.label1.Text = "VPC";
            // 
            // comboBoxVPC
            // 
            this.comboBoxVPC.FormattingEnabled = true;
            this.comboBoxVPC.Location = new System.Drawing.Point(20, 59);
            this.comboBoxVPC.Name = "comboBoxVPC";
            this.comboBoxVPC.Size = new System.Drawing.Size(123, 31);
            this.comboBoxVPC.TabIndex = 160;
            // 
            // groupBoxCreateTG
            // 
            this.groupBoxCreateTG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCreateTG.Controls.Add(this.buttonCreateTargetGroup);
            this.groupBoxCreateTG.Controls.Add(this.comboBoxVPC);
            this.groupBoxCreateTG.Controls.Add(this.label1);
            this.groupBoxCreateTG.Location = new System.Drawing.Point(22, 321);
            this.groupBoxCreateTG.Name = "groupBoxCreateTG";
            this.groupBoxCreateTG.Size = new System.Drawing.Size(742, 167);
            this.groupBoxCreateTG.TabIndex = 162;
            this.groupBoxCreateTG.TabStop = false;
            this.groupBoxCreateTG.Text = "Create Target Group";
            // 
            // buttonCreateTargetGroup
            // 
            this.buttonCreateTargetGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreateTargetGroup.Location = new System.Drawing.Point(20, 120);
            this.buttonCreateTargetGroup.Name = "buttonCreateTargetGroup";
            this.buttonCreateTargetGroup.Size = new System.Drawing.Size(118, 23);
            this.buttonCreateTargetGroup.TabIndex = 162;
            this.buttonCreateTargetGroup.Text = "Create";
            this.buttonCreateTargetGroup.UseVisualStyleBackColor = true;
            this.buttonCreateTargetGroup.Click += new System.EventHandler(this.buttonCreateTargetGroup_ClickAsync);
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
            this.groupBoxSelectHaGroup.ResumeLayout(false);
            this.groupBoxCreateTG.ResumeLayout(false);
            this.groupBoxCreateTG.PerformLayout();
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
    }
}
