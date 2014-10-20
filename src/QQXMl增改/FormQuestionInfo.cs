using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQXMl增改
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormQuestionInfo : Form
    {   
        #region Properties  
        public string Title { get; set; }   
        public string Content { get; set; } 
        public string IsOk { get; set; }   
        #endregion 
        #region Ctor
     
        public FormQuestionInfo()
        {
            InitializeComponent();

            btnOk.Click += btnOk_Click;

            btnCancel.Click += btnCancel_Click;

        }

        public FormQuestionInfo(string title, string content, bool isOk)
            : this()
        {
            Title = title;
            Content = content;
            IsOk = isOk.ToString();

            tbTitle.Text = title;
            tbConternt.Text = content;
            rabIsOk.Checked = isOk;
        }    
        
        #endregion
        #region EventHandle

        void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        void btnOk_Click(object sender, EventArgs e)
        {

            Title = tbTitle.Text.Trim();
            Content = tbConternt.Text.Trim();
            IsOk = rabIsOk.Checked.ToString();
            DialogResult = DialogResult.OK;

        }
        
        #endregion  
    }
}
