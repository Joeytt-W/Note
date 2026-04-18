namespace CodeMan.RabbitMq.Base.RabbitMq.Config
{
    public class RabbitOption
    {
        /// <summary>
        /// 主机名称
        /// </summary>
        public string Hostname { get; set; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 虚拟主机
        /// </summary>
        public string VirtualHost { get; set; }
    }
}