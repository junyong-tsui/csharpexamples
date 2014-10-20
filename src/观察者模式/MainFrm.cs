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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            this.Load += MainFrm_Load;
        }

        void MainFrm_Load(object sender, EventArgs e)
        {
            //1创建订阅者和发布者
            SubscriberFrm observerFrm = new SubscriberFrm();
            PublisherFrm publisherFrm = new PublisherFrm();

            //2订阅者订阅
            publisherFrm.ObserverManager.AttachObserver(observerFrm);

            //3主界面显示发布者和订阅者的窗体
            observerFrm.Show();
            publisherFrm.Show();
        }
    }
}
