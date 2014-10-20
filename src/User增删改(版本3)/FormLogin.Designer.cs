namespace User增删改_版本3_
{
	partial class FormLogin
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
            this.labAccount = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.labPwd = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Location = new System.Drawing.Point(13, 14);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(41, 12);
            this.labAccount.TabIndex = 0;
            this.labAccount.Text = "帐号：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(62, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(241, 21);
            this.txtName.TabIndex = 1;
            this.txtName.Text = "steve";
            // 
            // labPwd
            // 
            this.labPwd.AutoSize = true;
            this.labPwd.Location = new System.Drawing.Point(13, 65);
            this.labPwd.Name = "labPwd";
            this.labPwd.Size = new System.Drawing.Size(41, 12);
            this.labPwd.TabIndex = 0;
            this.labPwd.Text = "密码：";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(62, 62);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(241, 21);
            this.txtPwd.TabIndex = 1;
            this.txtPwd.Text = "steve123";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(140, 117);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(228, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 150);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.labPwd);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labAccount);
            this.Name = "FormLogin";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labAccount;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label labPwd;
		private System.Windows.Forms.TextBox txtPwd;
		private System.Windows.Forms.Button btnLogin;
		private System.Windows.Forms.Button btnCancel;
	}
}