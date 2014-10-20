using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 观察者模式
{
    /// <summary>
    /// 观察者窗体
    /// </summary>
    public partial class SubscriberFrm : Form,IUpdateText
    {
        #region Constructor
        public SubscriberFrm()
        {
            InitializeComponent();
        }
        #endregion
        #region IUpdateText

        public void SetText(string msg)
        {
            this.txtMsg.Text = msg;
        }
        
        #endregion
    }
}
