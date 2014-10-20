namespace RockBonusDemo_2_
{
    partial class RockBonusFrm
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
            this.labRock = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.labRockNum1 = new System.Windows.Forms.Label();
            this.labRockNum3 = new System.Windows.Forms.Label();
            this.labRockNum4 = new System.Windows.Forms.Label();
            this.labRockNum5 = new System.Windows.Forms.Label();
            this.labRockNum6 = new System.Windows.Forms.Label();
            this.labRockNum2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labRock
            // 
            this.labRock.AutoSize = true;
            this.labRock.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRock.Location = new System.Drawing.Point(171, 19);
            this.labRock.Name = "labRock";
            this.labRock.Size = new System.Drawing.Size(56, 16);
            this.labRock.TabIndex = 0;
            this.labRock.Text = "摇奖机";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(61, 127);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(279, 127);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 3;
            this.btnEnd.Text = "结束";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // labRockNum1
            // 
            this.labRockNum1.AutoSize = true;
            this.labRockNum1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum1.Location = new System.Drawing.Point(58, 70);
            this.labRockNum1.Name = "labRockNum1";
            this.labRockNum1.Size = new System.Drawing.Size(16, 16);
            this.labRockNum1.TabIndex = 1;
            this.labRockNum1.Text = "6";
            // 
            // labRockNum3
            // 
            this.labRockNum3.AutoSize = true;
            this.labRockNum3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum3.Location = new System.Drawing.Point(170, 70);
            this.labRockNum3.Name = "labRockNum3";
            this.labRockNum3.Size = new System.Drawing.Size(16, 16);
            this.labRockNum3.TabIndex = 2;
            this.labRockNum3.Text = "9";
            // 
            // labRockNum4
            // 
            this.labRockNum4.AutoSize = true;
            this.labRockNum4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum4.Location = new System.Drawing.Point(226, 70);
            this.labRockNum4.Name = "labRockNum4";
            this.labRockNum4.Size = new System.Drawing.Size(16, 16);
            this.labRockNum4.TabIndex = 2;
            this.labRockNum4.Text = "9";
            // 
            // labRockNum5
            // 
            this.labRockNum5.AutoSize = true;
            this.labRockNum5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum5.Location = new System.Drawing.Point(282, 70);
            this.labRockNum5.Name = "labRockNum5";
            this.labRockNum5.Size = new System.Drawing.Size(16, 16);
            this.labRockNum5.TabIndex = 2;
            this.labRockNum5.Text = "9";
            // 
            // labRockNum6
            // 
            this.labRockNum6.AutoSize = true;
            this.labRockNum6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum6.Location = new System.Drawing.Point(338, 70);
            this.labRockNum6.Name = "labRockNum6";
            this.labRockNum6.Size = new System.Drawing.Size(16, 16);
            this.labRockNum6.TabIndex = 2;
            this.labRockNum6.Text = "9";
            // 
            // labRockNum2
            // 
            this.labRockNum2.AutoSize = true;
            this.labRockNum2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labRockNum2.Location = new System.Drawing.Point(114, 70);
            this.labRockNum2.Name = "labRockNum2";
            this.labRockNum2.Size = new System.Drawing.Size(16, 16);
            this.labRockNum2.TabIndex = 2;
            this.labRockNum2.Text = "9";
            // 
            // RockBonusFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 179);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labRockNum6);
            this.Controls.Add(this.labRockNum5);
            this.Controls.Add(this.labRockNum4);
            this.Controls.Add(this.labRockNum3);
            this.Controls.Add(this.labRockNum2);
            this.Controls.Add(this.labRockNum1);
            this.Controls.Add(this.labRock);
            this.Name = "RockBonusFrm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labRock;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label labRockNum1;
        private System.Windows.Forms.Label labRockNum3;
        private System.Windows.Forms.Label labRockNum4;
        private System.Windows.Forms.Label labRockNum5;
        private System.Windows.Forms.Label labRockNum6;
        private System.Windows.Forms.Label labRockNum2;
    }
}

