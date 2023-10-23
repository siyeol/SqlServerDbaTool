namespace HaTool.HighAvailability
{
    partial class UcLoadBalancer
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
            this.groupBoxLoadBalancer = new System.Windows.Forms.GroupBox();
            this.groupBoxServer = new System.Windows.Forms.GroupBox();
            this.buttonSetHA = new System.Windows.Forms.Button();
            this.comboBoxMasterServer = new System.Windows.Forms.ComboBox();
            this.labelSlaveServer = new System.Windows.Forms.Label();
            this.labelMasterServer = new System.Windows.Forms.Label();
            this.comboBoxSlaveServer = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonServerListReload = new System.Windows.Forms.Button();
            this.buttonShowLBDetail = new System.Windows.Forms.Button();
            this.dgvloadBalancerList = new System.Windows.Forms.DataGridView();
            this.buttonLoadBalancerListReload = new System.Windows.Forms.Button();
            this.buttonDeleteLoadBalancer = new System.Windows.Forms.Button();
            this.groupBoxLoadBalancer.SuspendLayout();
            this.groupBoxServer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvloadBalancerList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxLoadBalancer
            // 
            this.groupBoxLoadBalancer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLoadBalancer.Controls.Add(this.groupBoxServer);
            this.groupBoxLoadBalancer.Controls.Add(this.groupBox1);
            this.groupBoxLoadBalancer.Location = new System.Drawing.Point(1, 3);
            this.groupBoxLoadBalancer.Name = "groupBoxLoadBalancer";
            this.groupBoxLoadBalancer.Size = new System.Drawing.Size(894, 694);
            this.groupBoxLoadBalancer.TabIndex = 1;
            this.groupBoxLoadBalancer.TabStop = false;
            this.groupBoxLoadBalancer.Text = "High Availability > Check Load Balancer and HA";
            // 
            // groupBoxServer
            // 
            this.groupBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxServer.Controls.Add(this.buttonSetHA);
            this.groupBoxServer.Controls.Add(this.comboBoxMasterServer);
            this.groupBoxServer.Controls.Add(this.labelSlaveServer);
            this.groupBoxServer.Controls.Add(this.labelMasterServer);
            this.groupBoxServer.Controls.Add(this.comboBoxSlaveServer);
            this.groupBoxServer.Location = new System.Drawing.Point(22, 583);
            this.groupBoxServer.Name = "groupBoxServer";
            this.groupBoxServer.Size = new System.Drawing.Size(853, 105);
            this.groupBoxServer.TabIndex = 68;
            this.groupBoxServer.TabStop = false;
            this.groupBoxServer.Text = "HA Allocation Server";
            // 
            // buttonSetHA
            // 
            this.buttonSetHA.Location = new System.Drawing.Point(23, 70);
            this.buttonSetHA.Name = "buttonSetHA";
            this.buttonSetHA.Size = new System.Drawing.Size(118, 23);
            this.buttonSetHA.TabIndex = 67;
            this.buttonSetHA.Text = "Set HA";
            this.buttonSetHA.UseVisualStyleBackColor = true;
            this.buttonSetHA.Click += new System.EventHandler(this.buttonSetHA_Click);
            // 
            // comboBoxMasterServer
            // 
            this.comboBoxMasterServer.FormattingEnabled = true;
            this.comboBoxMasterServer.Location = new System.Drawing.Point(23, 41);
            this.comboBoxMasterServer.Name = "comboBoxMasterServer";
            this.comboBoxMasterServer.Size = new System.Drawing.Size(316, 23);
            this.comboBoxMasterServer.TabIndex = 61;
            // 
            // labelSlaveServer
            // 
            this.labelSlaveServer.AutoSize = true;
            this.labelSlaveServer.Location = new System.Drawing.Point(350, 23);
            this.labelSlaveServer.Name = "labelSlaveServer";
            this.labelSlaveServer.Size = new System.Drawing.Size(91, 15);
            this.labelSlaveServer.TabIndex = 64;
            this.labelSlaveServer.Text = "Slave Server";
            // 
            // labelMasterServer
            // 
            this.labelMasterServer.AutoSize = true;
            this.labelMasterServer.Location = new System.Drawing.Point(27, 23);
            this.labelMasterServer.Name = "labelMasterServer";
            this.labelMasterServer.Size = new System.Drawing.Size(98, 15);
            this.labelMasterServer.TabIndex = 63;
            this.labelMasterServer.Text = "Master Server";
            // 
            // comboBoxSlaveServer
            // 
            this.comboBoxSlaveServer.FormattingEnabled = true;
            this.comboBoxSlaveServer.Location = new System.Drawing.Point(344, 41);
            this.comboBoxSlaveServer.Name = "comboBoxSlaveServer";
            this.comboBoxSlaveServer.Size = new System.Drawing.Size(325, 23);
            this.comboBoxSlaveServer.TabIndex = 62;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonServerListReload);
            this.groupBox1.Controls.Add(this.buttonShowLBDetail);
            this.groupBox1.Controls.Add(this.dgvloadBalancerList);
            this.groupBox1.Controls.Add(this.buttonLoadBalancerListReload);
            this.groupBox1.Controls.Add(this.buttonDeleteLoadBalancer);
            this.groupBox1.Location = new System.Drawing.Point(22, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 555);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Load Balancer List";
            // 
            // buttonServerListReload
            // 
            this.buttonServerListReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonServerListReload.Location = new System.Drawing.Point(259, 521);
            this.buttonServerListReload.Name = "buttonServerListReload";
            this.buttonServerListReload.Size = new System.Drawing.Size(118, 23);
            this.buttonServerListReload.TabIndex = 67;
            this.buttonServerListReload.Text = "Load HA Info";
            this.buttonServerListReload.UseVisualStyleBackColor = true;
            this.buttonServerListReload.Click += new System.EventHandler(this.buttonServerListReload_Click);
            // 
            // buttonShowLBDetail
            // 
            this.buttonShowLBDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowLBDetail.Location = new System.Drawing.Point(132, 521);
            this.buttonShowLBDetail.Name = "buttonShowLBDetail";
            this.buttonShowLBDetail.Size = new System.Drawing.Size(123, 23);
            this.buttonShowLBDetail.TabIndex = 67;
            this.buttonShowLBDetail.Text = "Show Detail";
            this.buttonShowLBDetail.UseVisualStyleBackColor = true;
            this.buttonShowLBDetail.Click += new System.EventHandler(this.buttonShowLBDetail_Click);
            // 
            // dgvloadBalancerList
            // 
            this.dgvloadBalancerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvloadBalancerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvloadBalancerList.Location = new System.Drawing.Point(19, 22);
            this.dgvloadBalancerList.Name = "dgvloadBalancerList";
            this.dgvloadBalancerList.RowHeadersWidth = 62;
            this.dgvloadBalancerList.Size = new System.Drawing.Size(821, 493);
            this.dgvloadBalancerList.TabIndex = 1;
            // 
            // buttonLoadBalancerListReload
            // 
            this.buttonLoadBalancerListReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoadBalancerListReload.Location = new System.Drawing.Point(19, 521);
            this.buttonLoadBalancerListReload.Name = "buttonLoadBalancerListReload";
            this.buttonLoadBalancerListReload.Size = new System.Drawing.Size(107, 23);
            this.buttonLoadBalancerListReload.TabIndex = 39;
            this.buttonLoadBalancerListReload.Text = "Reload";
            this.buttonLoadBalancerListReload.UseVisualStyleBackColor = true;
            this.buttonLoadBalancerListReload.Click += new System.EventHandler(this.buttonLoadBalancerListReload_Click);
            // 
            // buttonDeleteLoadBalancer
            // 
            this.buttonDeleteLoadBalancer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDeleteLoadBalancer.Location = new System.Drawing.Point(381, 521);
            this.buttonDeleteLoadBalancer.Name = "buttonDeleteLoadBalancer";
            this.buttonDeleteLoadBalancer.Size = new System.Drawing.Size(118, 23);
            this.buttonDeleteLoadBalancer.TabIndex = 59;
            this.buttonDeleteLoadBalancer.Text = "Delete";
            this.buttonDeleteLoadBalancer.UseVisualStyleBackColor = true;
            this.buttonDeleteLoadBalancer.Click += new System.EventHandler(this.buttonDeleteLoadBalancerInstance_Click);
            // 
            // UcLoadBalancer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBoxLoadBalancer);
            this.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Name = "UcLoadBalancer";
            this.Size = new System.Drawing.Size(900, 700);
            this.Load += new System.EventHandler(this.LoadData);
            this.groupBoxLoadBalancer.ResumeLayout(false);
            this.groupBoxServer.ResumeLayout(false);
            this.groupBoxServer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvloadBalancerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxLoadBalancer;
        private System.Windows.Forms.DataGridView dgvloadBalancerList;
        private System.Windows.Forms.Button buttonLoadBalancerListReload;
        private System.Windows.Forms.Button buttonDeleteLoadBalancer;
        private System.Windows.Forms.Button buttonShowLBDetail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxServer;
        private System.Windows.Forms.Button buttonServerListReload;
        private System.Windows.Forms.ComboBox comboBoxMasterServer;
        private System.Windows.Forms.Label labelSlaveServer;
        private System.Windows.Forms.Label labelMasterServer;
        private System.Windows.Forms.ComboBox comboBoxSlaveServer;
        private System.Windows.Forms.Button buttonSetHA;
    }
}
