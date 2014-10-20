namespace 对xml用winform进行增删改查
{
	partial class FormUserList
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
			this.girdUserList = new System.Windows.Forms.DataGridView();
			this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnPassword = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.girdUserList)).BeginInit();
			this.SuspendLayout();
			// 
			// girdUserList
			// 
			this.girdUserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.girdUserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnPassword});
			this.girdUserList.Location = new System.Drawing.Point(12, 12);
			this.girdUserList.Name = "girdUserList";
			this.girdUserList.RowTemplate.Height = 23;
			this.girdUserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.girdUserList.Size = new System.Drawing.Size(394, 333);
			this.girdUserList.TabIndex = 0;
			// 
			// ColumnId
			// 
			this.ColumnId.DataPropertyName = "Id";
			this.ColumnId.HeaderText = "用户编号";
			this.ColumnId.Name = "ColumnId";
			// 
			// ColumnName
			// 
			this.ColumnName.DataPropertyName = "Name";
			this.ColumnName.HeaderText = "用户姓名";
			this.ColumnName.Name = "ColumnName";
			// 
			// ColumnPassword
			// 
			this.ColumnPassword.DataPropertyName = "Password";
			this.ColumnPassword.HeaderText = "用户密码";
			this.ColumnPassword.Name = "ColumnPassword";
			this.ColumnPassword.Width = 150;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(431, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(126, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "新增用户";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(BtnAddClick);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(431, 59);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(126, 23);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "编辑用户";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.BtnEditClick);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(431, 106);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(126, 23);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "删除用户";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// FormUserList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(583, 356);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.girdUserList);
			this.Name = "FormUserList";
			this.Text = "用户列表";     
			((System.ComponentModel.ISupportInitialize)(this.girdUserList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView girdUserList;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
		private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPassword;

	}
}