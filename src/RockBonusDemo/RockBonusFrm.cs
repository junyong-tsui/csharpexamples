using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockBonusDemo
{
    /*
     * -----------需求--------------
     * 01点击开始按钮 开始摇奖
     * 02点击结束按钮 停止摇奖
     * 
     * -----------分析--------------
     * 01点击开始按钮后 摇奖能在主程序吗？
     *     显然不能，否则主窗体不能和用户交互了。只能开个线程完成摇奖号码的任务，其实这里面是个死循环。
     * 01点击停止按钮后 如何让01中的辅助线程停止摇奖？
     *     显然只需要挂起线程即可，在再次点击开始的时候恢复线程的执行。
     */


    /// <summary>
    /// 摇奖机的主界面
    /// </summary>
    public partial class RockBonusFrm : Form
    {
        /// <summary>
        /// 负责摇奖的线程
        /// </summary>
        Thread _rockThread;

        public RockBonusFrm()
        {
            InitializeComponent();
            this.Load += RockBonusFrm_Load;
        }

        /// <summary>
        /// 窗体加载时候创建摇奖的辅助线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void RockBonusFrm_Load(object sender, EventArgs e)
        {
            //设置摇奖号码的处理程序
            var setRockNumHandler = new Action<Label, string>(SetRockNum);

            //随机数源
            var rd = new Random();

            _rockThread = new Thread(() =>
            {
                while (true)
                {
                    labRockNum1.Invoke(setRockNumHandler, labRockNum1, rd.Next(10).ToString());
                    labRockNum2.Invoke(setRockNumHandler, labRockNum2, rd.Next(10).ToString());
                    labRockNum3.Invoke(setRockNumHandler, labRockNum3, rd.Next(10).ToString());
                    labRockNum4.Invoke(setRockNumHandler, labRockNum4, rd.Next(10).ToString());
                    labRockNum5.Invoke(setRockNumHandler, labRockNum5, rd.Next(10).ToString());
                    labRockNum6.Invoke(setRockNumHandler, labRockNum6, rd.Next(10).ToString());
                    Thread.Sleep(100);
                }
            });

            _rockThread.IsBackground = true;
        }

        /// <summary>
        /// 开始摇奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_rockThread.ThreadState == (ThreadState.Unstarted|ThreadState.Background))
            {
                _rockThread.Start();
            }

            if (_rockThread.ThreadState == (ThreadState.Suspended|ThreadState.Background))
            {
                _rockThread.Resume();
            }
        }

        /// <summary>
        /// 停止摇奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            _rockThread.Suspend();            
        }
       
        /// <summary>
        /// 设置摇奖号码
        /// </summary>
        /// <param name="lable"></param>
        /// <param name="rockNum"></param>
        private void SetRockNum(Label lable, string rockNum)
        {
            lable.Text = rockNum;
        }
    }
}
