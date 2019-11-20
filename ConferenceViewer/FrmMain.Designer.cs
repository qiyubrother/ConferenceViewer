namespace ConferenceViewer
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnGetSpeakerVolume = new System.Windows.Forms.Button();
            this.btnSetSpeaker = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRtnVolume = new System.Windows.Forms.TextBox();
            this.btnGetMicphoneVolume = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSetMicPhoneVolume = new System.Windows.Forms.Button();
            this.btnCancelMute = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnCancelMuteAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.btnMuteAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtConference = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnQueryAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.splitContainer1.Panel1.Controls.Add(this.btnQueryAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetSpeakerVolume);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetSpeaker);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.txtRtnVolume);
            this.splitContainer1.Panel1.Controls.Add(this.btnGetMicphoneVolume);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.btnSetMicPhoneVolume);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancelMute);
            this.splitContainer1.Panel1.Controls.Add(this.btnMute);
            this.splitContainer1.Panel1.Controls.Add(this.btnCancelMuteAll);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtUserCode);
            this.splitContainer1.Panel1.Controls.Add(this.btnMuteAll);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.txtConference);
            this.splitContainer1.Panel1.Controls.Add(this.txtPort);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddress);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1332, 450);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnGetSpeakerVolume
            // 
            this.btnGetSpeakerVolume.Location = new System.Drawing.Point(1112, 66);
            this.btnGetSpeakerVolume.Name = "btnGetSpeakerVolume";
            this.btnGetSpeakerVolume.Size = new System.Drawing.Size(131, 23);
            this.btnGetSpeakerVolume.TabIndex = 14;
            this.btnGetSpeakerVolume.Text = "Get Speaker Volume";
            this.btnGetSpeakerVolume.UseVisualStyleBackColor = true;
            this.btnGetSpeakerVolume.Click += new System.EventHandler(this.btnGetSpeakerVolume_Click);
            // 
            // btnSetSpeaker
            // 
            this.btnSetSpeaker.Location = new System.Drawing.Point(975, 66);
            this.btnSetSpeaker.Name = "btnSetSpeaker";
            this.btnSetSpeaker.Size = new System.Drawing.Size(131, 23);
            this.btnSetSpeaker.TabIndex = 13;
            this.btnSetSpeaker.Text = "Set Speaker Volume";
            this.btnSetSpeaker.UseVisualStyleBackColor = true;
            this.btnSetSpeaker.Click += new System.EventHandler(this.btnSetSpeaker_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1247, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Result";
            // 
            // txtRtnVolume
            // 
            this.txtRtnVolume.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRtnVolume.Location = new System.Drawing.Point(1249, 43);
            this.txtRtnVolume.Name = "txtRtnVolume";
            this.txtRtnVolume.Size = new System.Drawing.Size(53, 21);
            this.txtRtnVolume.TabIndex = 16;
            // 
            // btnGetMicphoneVolume
            // 
            this.btnGetMicphoneVolume.Location = new System.Drawing.Point(1112, 43);
            this.btnGetMicphoneVolume.Name = "btnGetMicphoneVolume";
            this.btnGetMicphoneVolume.Size = new System.Drawing.Size(131, 23);
            this.btnGetMicphoneVolume.TabIndex = 13;
            this.btnGetMicphoneVolume.Text = "Get MicPhone Volume";
            this.btnGetMicphoneVolume.UseVisualStyleBackColor = true;
            this.btnGetMicphoneVolume.Click += new System.EventHandler(this.btnGetMicphoneVolume_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(902, 43);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown1.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(900, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Volume";
            // 
            // btnSetMicPhoneVolume
            // 
            this.btnSetMicPhoneVolume.Location = new System.Drawing.Point(975, 43);
            this.btnSetMicPhoneVolume.Name = "btnSetMicPhoneVolume";
            this.btnSetMicPhoneVolume.Size = new System.Drawing.Size(131, 23);
            this.btnSetMicPhoneVolume.TabIndex = 12;
            this.btnSetMicPhoneVolume.Text = "Set MicPhone Volume";
            this.btnSetMicPhoneVolume.UseVisualStyleBackColor = true;
            this.btnSetMicPhoneVolume.Click += new System.EventHandler(this.btnSetMicPhoneVolume_Click);
            // 
            // btnCancelMute
            // 
            this.btnCancelMute.Location = new System.Drawing.Point(793, 41);
            this.btnCancelMute.Name = "btnCancelMute";
            this.btnCancelMute.Size = new System.Drawing.Size(90, 23);
            this.btnCancelMute.TabIndex = 11;
            this.btnCancelMute.Text = "Cancel Mute";
            this.btnCancelMute.UseVisualStyleBackColor = true;
            this.btnCancelMute.Click += new System.EventHandler(this.btnCancelMute_Click);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(712, 41);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(75, 23);
            this.btnMute.TabIndex = 10;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnCancelMuteAll
            // 
            this.btnCancelMuteAll.Location = new System.Drawing.Point(478, 41);
            this.btnCancelMuteAll.Name = "btnCancelMuteAll";
            this.btnCancelMuteAll.Size = new System.Drawing.Size(112, 23);
            this.btnCancelMuteAll.TabIndex = 9;
            this.btnCancelMuteAll.Text = "Cancel Mute All";
            this.btnCancelMuteAll.UseVisualStyleBackColor = true;
            this.btnCancelMuteAll.Click += new System.EventHandler(this.btnCancelMuteAll_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(627, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "User Code";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Location = new System.Drawing.Point(627, 43);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Size = new System.Drawing.Size(79, 21);
            this.txtUserCode.TabIndex = 7;
            // 
            // btnMuteAll
            // 
            this.btnMuteAll.Location = new System.Drawing.Point(397, 41);
            this.btnMuteAll.Name = "btnMuteAll";
            this.btnMuteAll.Size = new System.Drawing.Size(75, 23);
            this.btnMuteAll.TabIndex = 6;
            this.btnMuteAll.Text = "Mute All";
            this.btnMuteAll.UseVisualStyleBackColor = true;
            this.btnMuteAll.Click += new System.EventHandler(this.btnMuteAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "Conference";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Address";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(316, 41);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtConference
            // 
            this.txtConference.Location = new System.Drawing.Point(231, 41);
            this.txtConference.Name = "txtConference";
            this.txtConference.Size = new System.Drawing.Size(79, 21);
            this.txtConference.TabIndex = 2;
            this.txtConference.Text = "35226";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(164, 41);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(61, 21);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8080";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(13, 41);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(145, 21);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "192.168.10.166";
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1332, 349);
            this.listBox1.TabIndex = 0;
            // 
            // btnQueryAll
            // 
            this.btnQueryAll.Location = new System.Drawing.Point(316, 70);
            this.btnQueryAll.Name = "btnQueryAll";
            this.btnQueryAll.Size = new System.Drawing.Size(79, 23);
            this.btnQueryAll.TabIndex = 18;
            this.btnQueryAll.Text = "Query All";
            this.btnQueryAll.UseVisualStyleBackColor = true;
            this.btnQueryAll.Click += new System.EventHandler(this.btnQueryAll_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.Text = "Conference Viewer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.Button btnMuteAll;
        private System.Windows.Forms.Button btnCancelMuteAll;
        private System.Windows.Forms.Button btnCancelMute;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnSetMicPhoneVolume;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnGetMicphoneVolume;
        private System.Windows.Forms.TextBox txtRtnVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetSpeaker;
        private System.Windows.Forms.Button btnGetSpeakerVolume;
        private System.Windows.Forms.Button btnQueryAll;
    }
}

