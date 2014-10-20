namespace 观察者模式
{
    partial class SubscriberFrm
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
            this.labObserver = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labObserver
            // 
            this.labObserver.AutoSize = true;
            this.labObserver.Location = new System.Drawing.Point(50, 19);
            this.labObserver.Name = "labObserver";
            this.labObserver.Size = new System.Drawing.Size(191, 12);
            this.labObserver.TabIndex = 0;
            this.labObserver.Text = "我是一个观察者:这是我收到的消息";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(52, 49);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(407, 21);
            this.txtMsg.TabIndex = 2;
            // 
            // ObserverFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 123);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.labObserver);
            this.Name = "ObserverFrm";
            this.Text = "ObserverFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labObserver;
        private System.Windows.Forms.TextBox txtMsg;
    }
}