using System.Collections.Generic;
using RabbitMQ.Client;

namespace CodeMan.RabbitMq.Base.RabbitMq.Config
{
    public class RabbitConnection
    {
        private readonly RabbitOption _config;
        private IConnection _connection = null;

        public RabbitConnection(RabbitOption config)
        {
            _config = config;
        }

        public IConnection GetConnection()
        {
            if (_connection == null)
            {
                if (string.IsNullOrEmpty(_config.Address))
                {
                    ConnectionFactory factory = new ConnectionFactory();
                    factory.HostName = _config.Hostname;
                    factory.Port = _config.Port;
                    factory.UserName = _config.Username;
                    factory.Password = _config.Password;
                    factory.VirtualHost = _config.VirtualHost;
                    _connection = factory.CreateConnection();
                }
                else//集群
                {
                    ConnectionFactory factory = new ConnectionFactory();
                    factory.UserName = _config.Username;
                    factory.Password = _config.Password;
                    factory.VirtualHost = _config.VirtualHost;

                    var address = _config.Address;
                    List<AmqpTcpEndpoint> endpoints = new List<AmqpTcpEndpoint>();
                    foreach (var endpoint in address.Split(","))
                    {
                        endpoints.Add(new AmqpTcpEndpoint(endpoint.Split(":")[0], int.Parse(endpoint.Split(":")[1])));
                    }
                    _connection = factory.CreateConnection(endpoints);
                }
                
            }

            return _connection;
        }
    }
}