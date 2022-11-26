namespace SocketClient
{
    partial class MainFrm
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
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendMsg.Location = new System.Drawing.Point(503, 461);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 15;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMsg.Location = new System.Drawing.Point(36, 461);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(415, 26);
            this.txtMsg.TabIndex = 14;
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLog.Location = new System.Drawing.Point(36, 76);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(623, 346);
            this.txtLog.TabIndex = 13;
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPort.Location = new System.Drawing.Point(398, 29);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(142, 26);
            this.txtPort.TabIndex = 12;
            this.txtPort.Text = "5000";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPort.Location = new System.Drawing.Point(273, 32);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(119, 16);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "服务端端口号：";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIP.Location = new System.Drawing.Point(106, 29);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(161, 26);
            this.txtIP.TabIndex = 10;
            this.txtIP.Text = "192.168.0.107";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIP.Location = new System.Drawing.Point(33, 32);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(79, 16);
            this.lblIP.TabIndex = 9;
            this.lblIP.Text = "服务端IP:";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("新宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnect.Location = new System.Drawing.Point(563, 29);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "连接";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 521);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.btnConnect);
            this.Name = "MainFrm";
            this.Text = "客户端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Button btnConnect;
    }
}