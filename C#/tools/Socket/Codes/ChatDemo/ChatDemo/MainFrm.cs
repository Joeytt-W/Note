using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChatDemo
{
    public partial class MainFrm : Form
    {
        public List<Socket> ClientProSocketList { get;} = new List<Socket>();  

        public MainFrm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text) || string.IsNullOrWhiteSpace(txtPort.Text))
            {
                MessageBox.Show("请输入服务端IP地址和端口号");
                return;
            }

            //创建Socket对象
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);    
            //绑定IP和端口号
            socket.Bind(new IPEndPoint(IPAddress.Parse(txtIP.Text), int.Parse(txtPort.Text)));
            //开启监听
            socket.Listen(10);//连接等待队列的长度,eg:同时有100个连接来，只保留10个等待连接，其他的返回错误
            
            //接收客户端连接
            ThreadPool.QueueUserWorkItem(AcceptClientConnect, socket);

        }

        /// <summary>
        /// 接收连接
        /// </summary>
        /// <param name="socket"></param>
        private void AcceptClientConnect(object socket)
        {
            //开始接收客户端连接
            AppendTextToLog("服务器端开始接收客户端连接");

            var serverSocket = socket as Socket;
            while (true)
            {
                try
                {
                    var proSocket = serverSocket.Accept();
                    ClientProSocketList.Add(proSocket);
                    AppendTextToLog($"客户端{proSocket.RemoteEndPoint.ToString()}连接成功");

                    //接收当前连接发送的数据
                    ThreadPool.QueueUserWorkItem(ReceiveClientData, proSocket);
                }
                catch (Exception e)
                {
                    AppendTextToLog($"接收连接异常:{e.Message}");
                    serverSocket.Close();
                }
                
            }
        }

        /// <summary>
        /// 发送消息到客户端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            foreach (var proSocket in ClientProSocketList)
            {
                if (proSocket.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes(txtMsg.Text);
                    proSocket.Send(data, 0, data.Length, SocketFlags.None);
                }
            }
        }

        /// <summary>
        /// 接收客户端信息
        /// </summary>
        private void ReceiveClientData(object socket)
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
                    AppendTextToLog($"接收客户端：{proSocket.RemoteEndPoint.ToString()}消息异常:{e.Message}");

                    ClientProSocketList.Remove(proSocket);

                    if (proSocket.Connected)
                    {
                        proSocket.Shutdown(SocketShutdown.Both);
                        proSocket.Close();
                    }
                    return;//结束线程
                }

                 
                if (len <= 0)
                {
                    //客户端正常退出
                    AppendTextToLog($"客户端：{proSocket.RemoteEndPoint.ToString()}正常退出");

                    ClientProSocketList.Remove(proSocket);
                    if (proSocket.Connected)
                    {
                        proSocket.Shutdown(SocketShutdown.Both);
                        proSocket.Close();
                    }
                    return;//结束线程
                }

                //显示接收数据
                string str = Encoding.UTF8.GetString(receiveData, 0, len);
                AppendTextToLog($"接收到客户端：{proSocket.RemoteEndPoint.ToString()}的消息：{str}");
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
    }
}
