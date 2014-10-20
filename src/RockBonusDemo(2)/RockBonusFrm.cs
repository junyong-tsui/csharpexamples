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

namespace RockBonusDemo_2_
{
    /*
     * -----------需求--------------
     * 01点击开始按钮 开始摇奖
     * 02点击结束按钮 停止摇奖
     * 
     * -----------分析--------------
     * 01点击开始按钮后 摇奖能在主程序吗？
     *     显然不能，否则主窗体不能和用户交互了。只能开个线程完成摇奖号码的任务，其实这里面是个死循环。
     * 02点击停止按钮后 如何让01中的辅助线程停止摇奖？
     *     方案1: 显然只需要挂起线程即可，在再次点击开始的时候恢复线程的执行。这是上个版本的写法,不适合了,现在挂起和恢复线程已不
     *   推荐使用了。
     *     方案2：利用.net闭包，用flag来控制线程的执行。
     */


    /// <summary>
    /// 摇奖机的主界面
    /// </summary>
    public partial class RockBonusFrm : Form
    {
        //控制摇奖是否继续
        bool flag;

        public RockBonusFrm()
        {
            InitializeComponent();          
        }

        /// <summary>
        /// 开始摇奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            flag = true;
            Random rd = new Random();           
            var setRockNumHandler = new Action<Label, string>(SetRockNum);

            #region 非线程池版  
            //创建线程实例=>设置为后台线程=>启动线程 三部曲 不要遗忘
            //Thread thread = new Thread(() =>
            //{
            //    while (flag)
            //    {
            //        labRockNum1.Invoke(setRockNumHandler, labRockNum1, rd.Next(10).ToString());
            //        labRockNum2.Invoke(setRockNumHandler, labRockNum2, rd.Next(10).ToString());
            //        labRockNum3.Invoke(setRockNumHandler, labRockNum3, rd.Next(10).ToString());
            //        labRockNum4.Invoke(setRockNumHandler, labRockNum4, rd.Next(10).ToString());
            //        labRockNum5.Invoke(setRockNumHandler, labRockNum5, rd.Next(10).ToString());
            //        labRockNum6.Invoke(setRockNumHandler, labRockNum6, rd.Next(10).ToString());
            //        Thread.Sleep(100);
            //    }
            //});
            //thread.IsBackground = true;
            //thread.Start();
            #endregion

            #region 线程池版
            ThreadPool.QueueUserWorkItem(s =>
            {
                while (flag)
                {
                    //这个地方的不能传匿名方法，lamda表达式,编译器无法推断为具体的委托类型。
                    labRockNum1.Invoke(setRockNumHandler, labRockNum1, rd.Next(10).ToString());
                    labRockNum2.Invoke(setRockNumHandler, labRockNum2, rd.Next(10).ToString());
                    labRockNum3.Invoke(setRockNumHandler, labRockNum3, rd.Next(10).ToString());
                    labRockNum4.Invoke(setRockNumHandler, labRockNum4, rd.Next(10).ToString());
                    labRockNum5.Invoke(setRockNumHandler, labRockNum5, rd.Next(10).ToString());
                    labRockNum6.Invoke(setRockNumHandler, labRockNum6, rd.Next(10).ToString());
                    Thread.Sleep(100);
                }
            },"hello");
            #endregion
        }

        /// <summary>
        /// 停止摇奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            flag = false;        
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
