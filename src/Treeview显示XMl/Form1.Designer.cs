﻿namespace Treeview显示XMl
{
    partial class Form1
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
            this.treeViewOrder1 = new Treeview显示XMl.TreeViewOrder();
            this.SuspendLayout();
            // 
            // treeViewOrder1
            // 
            this.treeViewOrder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewOrder1.Location = new System.Drawing.Point(0, 0);
            this.treeViewOrder1.Name = "treeViewOrder1";
            this.treeViewOrder1.Size = new System.Drawing.Size(293, 411);
            this.treeViewOrder1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 411);
            this.Controls.Add(this.treeViewOrder1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TreeViewOrder treeViewOrder1;
    }
}

