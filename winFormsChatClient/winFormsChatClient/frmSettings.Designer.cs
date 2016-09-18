namespace winFormsChatClient
{
    partial class frmSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProxyAuth = new System.Windows.Forms.CheckBox();
            this.cbProxyEnabled = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbProxyPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbProxyUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbProxySocket = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProxyAuth);
            this.groupBox1.Controls.Add(this.cbProxyEnabled);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.tbProxyPass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbProxyUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbProxySocket);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 212);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Proxy settings";
            // 
            // cbProxyAuth
            // 
            this.cbProxyAuth.AutoSize = true;
            this.cbProxyAuth.Checked = true;
            this.cbProxyAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProxyAuth.Location = new System.Drawing.Point(9, 82);
            this.cbProxyAuth.Name = "cbProxyAuth";
            this.cbProxyAuth.Size = new System.Drawing.Size(178, 17);
            this.cbProxyAuth.TabIndex = 8;
            this.cbProxyAuth.Text = "Am Proxy Server authentifizieren";
            this.cbProxyAuth.UseVisualStyleBackColor = true;
            this.cbProxyAuth.CheckedChanged += new System.EventHandler(this.cbProxyAuth_CheckedChanged);
            // 
            // cbProxyEnabled
            // 
            this.cbProxyEnabled.AutoSize = true;
            this.cbProxyEnabled.Checked = true;
            this.cbProxyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProxyEnabled.Location = new System.Drawing.Point(9, 28);
            this.cbProxyEnabled.Name = "cbProxyEnabled";
            this.cbProxyEnabled.Size = new System.Drawing.Size(133, 17);
            this.cbProxyEnabled.TabIndex = 7;
            this.cbProxyEnabled.Text = "Proxy Server benutzen";
            this.cbProxyEnabled.UseVisualStyleBackColor = true;
            this.cbProxyEnabled.CheckedChanged += new System.EventHandler(this.cbProxyEnabled_CheckedChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(297, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 41);
            this.button1.TabIndex = 6;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbProxyPass
            // 
            this.tbProxyPass.Location = new System.Drawing.Point(108, 131);
            this.tbProxyPass.Name = "tbProxyPass";
            this.tbProxyPass.Size = new System.Drawing.Size(265, 20);
            this.tbProxyPass.TabIndex = 5;
            this.tbProxyPass.Text = "TheGoldenHall5";
            this.tbProxyPass.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Proxy Passwort:";
            // 
            // tbProxyUser
            // 
            this.tbProxyUser.Location = new System.Drawing.Point(108, 105);
            this.tbProxyUser.Name = "tbProxyUser";
            this.tbProxyUser.Size = new System.Drawing.Size(265, 20);
            this.tbProxyUser.TabIndex = 3;
            this.tbProxyUser.Text = "droephil";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proxy Benutzer:";
            // 
            // tbProxySocket
            // 
            this.tbProxySocket.Location = new System.Drawing.Point(108, 51);
            this.tbProxySocket.Name = "tbProxySocket";
            this.tbProxySocket.Size = new System.Drawing.Size(265, 20);
            this.tbProxySocket.TabIndex = 1;
            this.tbProxySocket.Text = "debucsproxy.connect.ads:8080";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proxy IP + Port:";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 236);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSettings";
            this.Text = "frmSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbProxyPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbProxyUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbProxySocket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbProxyAuth;
        private System.Windows.Forms.CheckBox cbProxyEnabled;
    }
}