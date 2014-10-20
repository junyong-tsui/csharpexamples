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
    public partial class PublisherFrm : Form
    {
        #region State 
   
        ObserverManager _observerManager = new ObserverManager();
        /// <summary>
        /// 观察者的管理类
        /// </summary>
        public ObserverManager ObserverManager
        { 
            get { return _observerManager; } 
        }
        #endregion
        #region Constructor

        public PublisherFrm()
        {
            InitializeComponent();
        }

        #endregion
        #region Event hook

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (_observerManager == null) return;
            _observerManager.Dispatch(this.texPublisher.Text);
        }
        
        #endregion
    }
}
