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

namespace SocketClient
{
    public partial class MainFrm : Form
    {
        public Socket ClientSocket { get; set; }

        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //连接服务器
            //创建Socket
            Socket socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);

            ClientSocket = socket;

            //连接服务器
            try
            {
                socket.Connect(IPAddress.Parse(txtIP.Text),int.Parse(txtPort.Text));
            }
            catch (Exception exception)
            {
                MessageBox.Show($"连接失败:{exception.Message}");
                return;
            }

            //发送消息,接收消息
            Thread thread = new Thread(ReceiveServerData);
            thread.IsBackground = true;
            thread.Start(ClientSocket);

        }

        /// <summary>
        /// 发送消息到服务端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (ClientSocket.Connected)
            {
                byte[] data = Encoding.UTF8.GetBytes(txtMsg.Text);
                ClientSocket.Send(data, 0, data.Length, SocketFlags.None);
            }
        }

        /// <summary>
        /// 接收服务端信息
        /// </summary>
        private void ReceiveServerData(object socket)
        {
            var proSocket = socket as Socket;
            byte[] receiveData = new byte[1024 * 1024];
            while (true)
            {
                int len = 0;
                try
                {
                    len = proSocket.Receive(receiveData, 0, receiveData.Length, SocketFlags.None);
                }
                catch (Exception e)
                {
                    //异常
                    AppendTextToLog($"接收服务端：{proSocket.RemoteEndPoint.ToString()}消息异常:{e.Message}");

                    if (ClientSocket.Connected)
                    {
                        ClientSocket.Shutdown(SocketShutdown.Both);
                        ClientSocket.Close(100);
                    }
                    return;//结束线程
                }


                if (len <= 0)
                {
                    //客户端正常退出
                    AppendTextToLog($"客户端：{proSocket.RemoteEndPoint.ToString()}正常退出");

                    if (ClientSocket.Connected)
                    {
                        ClientSocket.Shutdown(SocketShutdown.Both);
                        ClientSocket.Close(100);
                    }
                    return;//结束线程
                }

                //显示接收数据
                string str = Encoding.UTF8.GetString(receiveData, 0, len);
                AppendTextToLog($"接收到服务端：{proSocket.RemoteEndPoint.ToString()}的消息：{str}");
            }
        }

        /// <summary>
        /// 写日志到txtLog
        /// </summary>
        /// <param name="text"></param>
        private void AppendTextToLog(string text)
        {
            if (txtLog.InvokeRequired)
            {
                txtLog.BeginInvoke(new Action<string>(s =>
                {
                    txtLog.AppendText($"{s}\r\n");
                }), text);
            }
            else
            {
                txtLog.AppendText($"{text}\r\n");
            }
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClientSocket.Connected)
            {
                ClientSocket.Shutdown(SocketShutdown.Both);
                ClientSocket.Close(100);
            }
        }
    }
}
