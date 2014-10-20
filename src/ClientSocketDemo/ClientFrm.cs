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

namespace ClientSocketDemo
{
    public partial class ClientFrm : Form
    {
        Socket clientSocket;
        public ClientFrm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //1客户端连接服务器端
            //1创建socket对象
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IPv4);

            //2连接服务端 连接后客户端会自动给客户端的套接字分配ip和端口
            try
            {
                clientSocket.Connect(IPAddress.Parse(txtIp.Text), Convert.ToInt32(txtPort.Text));
            }
            catch (Exception err)
            {
                if (!(err is SocketException)) return;

                //过一会再自动重连
                Thread.Sleep(5000);

                btnConnect_Click(this, e);
            }

            
            #region 3接收服务端的数据
          
            ThreadPool.QueueUserWorkItem(obj =>
            {
                var socket = obj as Socket;
                byte[] msg = new byte[1024 * 1024];
                int realLength = 0;
                while (true)
                {
                    try
                    {
                        realLength = socket.Receive(msg, SocketFlags.None);
                    }
                    //服务端异常退出
                    catch (Exception)
                    {
                        AppentMsgToReceiveText("服务端异常退出");
                        StopConnect();
                    }
                    //服务端正常退出
                    if (realLength <= 0)
                    {
                        AppentMsgToReceiveText("服务端正常退出");
                        StopConnect();
                    }

                    #region 接收字符串

                    #endregion

                    #region 接收闪屏

                    #endregion

                    #region 接收文件

                    #endregion

                }
            }, clientSocket);

            #endregion
        }

        /// <summary>
        /// 停止连接服务端
        /// </summary>
        private void StopConnect()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        /// <summary>
        /// 拼接消息至接收消息的文本
        /// </summary>
        private void AppentMsgToReceiveText(string msg)
        {
            if (this.txtReceiveMsg.InvokeRequired)
            {
                this.txtReceiveMsg.Invoke(new Action<string>(s => { }), msg);
            }
            else
            {
                this.txtReceiveMsg.Text = "" + "" + msg;
            }            
        }
    }
}
