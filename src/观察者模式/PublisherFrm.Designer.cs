namespace 观察者模式
{
    partial class PublisherFrm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.texPublisher = new System.Windows.Forms.TextBox();
            this.labPublisher = new System.Windows.Forms.Label();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texPublisher
            // 
            this.texPublisher.Location = new System.Drawing.Point(69, 39);
            this.texPublisher.Name = "texPublisher";
            this.texPublisher.Size = new System.Drawing.Size(354, 21);
            this.texPublisher.TabIndex = 0;
            // 
            // labPublisher
            // 
            this.labPublisher.AutoSize = true;
            this.labPublisher.Location = new System.Drawing.Point(67, 9);
            this.labPublisher.Name = "labPublisher";
            this.labPublisher.Size = new System.Drawing.Size(221, 12);
            this.labPublisher.TabIndex = 1;
            this.labPublisher.Text = "我是一个发布者，下面是我要通知的消息";
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Location = new System.Drawing.Point(69, 86);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 2;
            this.btnSendMsg.Text = "通知";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 144);
            this.Controls.Add(this.btnSendMsg);
            this.Controls.Add(this.labPublisher);
            this.Controls.Add(this.texPublisher);
            this.Name = "Form1";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox texPublisher;
        private System.Windows.Forms.Label labPublisher;
        private System.Windows.Forms.Button btnSendMsg;
    }
}

