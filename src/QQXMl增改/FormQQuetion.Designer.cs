namespace QQXMl增改
{
    partial class FormQQuetion
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvQQQustion = new System.Windows.Forms.TreeView();
            this.rbIsSolve = new System.Windows.Forms.RadioButton();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.labContent = new System.Windows.Forms.Label();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.labTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvQQQustion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rbIsSolve);
            this.splitContainer1.Panel2.Controls.Add(this.tbContent);
            this.splitContainer1.Panel2.Controls.Add(this.labContent);
            this.splitContainer1.Panel2.Controls.Add(this.tbTitle);
            this.splitContainer1.Panel2.Controls.Add(this.labTitle);
            this.splitContainer1.Size = new System.Drawing.Size(602, 424);
            this.splitContainer1.SplitterDistance = 200;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvQQQustion
            // 
            this.tvQQQustion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvQQQustion.Location = new System.Drawing.Point(0, 0);
            this.tvQQQustion.Name = "tvQQQustion";
            this.tvQQQustion.Size = new System.Drawing.Size(200, 424);
            this.tvQQQustion.TabIndex = 0;
            // 
            // rbIsSolve
            // 
            this.rbIsSolve.AutoSize = true;
            this.rbIsSolve.Location = new System.Drawing.Point(67, 363);
            this.rbIsSolve.Name = "rbIsSolve";
            this.rbIsSolve.Size = new System.Drawing.Size(59, 16);
            this.rbIsSolve.TabIndex = 2;
            this.rbIsSolve.TabStop = true;
            this.rbIsSolve.Text = "已解决";
            this.rbIsSolve.UseVisualStyleBackColor = true;
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(67, 65);
            this.tbContent.Multiline = true;
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(293, 261);
            this.tbContent.TabIndex = 1;
            // 
            // labContent
            // 
            this.labContent.AutoSize = true;
            this.labContent.Location = new System.Drawing.Point(18, 68);
            this.labContent.Name = "labContent";
            this.labContent.Size = new System.Drawing.Size(29, 12);
            this.labContent.TabIndex = 0;
            this.labContent.Text = "内容";
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(67, 17);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(293, 21);
            this.tbTitle.TabIndex = 1;
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(18, 20);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(29, 12);
            this.labTitle.TabIndex = 0;
            this.labTitle.Text = "标题";
            // 
            // FormQQQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 424);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormQQQuestion";
            this.Text = "QQ问题";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvQQQustion;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.Label labContent;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.RadioButton rbIsSolve;
    }
}

