using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PDemo
{
    public partial class CommunicationFrm : Form
    {
        #region Field
        
        /// <summary>
        /// 
        /// </summary>       
        Socket communicationSocket;

        #endregion
    
        #region constructor        
       
        public CommunicationFrm()
        {
            InitializeComponent();
            this.FormClosing += CommunicationFrm_FormClosing;
            this.Load += CommunicationFrm_Load;
        }


        public CommunicationFrm(Socket communicationSocket)
            : this()
        {
            this.communicationSocket = communicationSocket;
        }

        #endregion
      
        #region Send Msg to Client       
        
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = txtSendMsg.Text;
            byte[] encryptMsg = Encoding.UTF8.GetBytes(msg);
            communicationSocket.Send(encryptMsg);
        }

        #endregion

        #region  Receive Msg from Client

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommunicationFrm_Load(object sender, EventArgs e)
        {
            //1 加载用户的信息
            IPEndPoint localIPEndPoint= communicationSocket.LocalEndPoint as IPEndPoint;

            txtIp.Text = Dns.GetHostEntry(localIPEndPoint.Address).HostName;//根据ipAddress找主机名

            txtPort.Text = localIPEndPoint.Port.ToString();

            //2开始接受消息
            ReceiveMsg();
        }        

        /// <summary>
        /// 接收消息
        /// </summary>
        void ReceiveMsg()
        {           
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                byte[] msg = new byte[1024 * 1024];
                int realLength = 0;             
                while (true)
                {
                    try
                    {
                        realLength = communicationSocket.Receive(msg, SocketFlags.None);
                        if (realLength <= 0)
                        {
                            ShutCommnunicationSocket(communicationSocket);
                            return;
                        }                       
                        AppentMsgToReceiveText(Encoding.UTF8.GetString(msg, 0, realLength));
                    }
                    catch (Exception)
                    {
                        ShutCommnunicationSocket(communicationSocket);
                        return;
                    }
                }
            }, null);
        }

        /// <summary>
        /// 拼接消息至接收消息的文本
        /// </summary>
        public void AppentMsgToReceiveText(string msg)
        {
            if (this.txtReceiveMsg.InvokeRequired)
            {
                this.txtReceiveMsg.Invoke(new Action<string>(s => { this.txtReceiveMsg.Text = s + this.txtReceiveMsg.Text; }), msg);
            }
            else
            {
                this.txtReceiveMsg.Text = msg + this.txtReceiveMsg.Text;
            }
        }

        #endregion

        #region Close the commnunicationSocket

        /// <summary>
        /// 关闭和服务端通信的套接字
        /// </summary>
        /// <param name="commnunicationSocket"></param>
        private void ShutCommnunicationSocket(Socket commnunicationSocket)
        {
            if (communicationSocket.Connected)
            {
                commnunicationSocket.Shutdown(SocketShutdown.Both);
                commnunicationSocket.Close();
                this.Close();
            }          
        }

        /// <summary>
        /// 窗体关闭的时候关闭套接字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CommunicationFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (communicationSocket.Connected)
            {
                communicationSocket.Shutdown(SocketShutdown.Both);
                communicationSocket.Close();    
            }                 
        }

        #endregion
    }
}
