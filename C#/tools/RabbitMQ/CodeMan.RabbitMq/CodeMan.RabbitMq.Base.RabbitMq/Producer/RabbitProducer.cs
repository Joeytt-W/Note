using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CodeMan.RabbitMq.Base.RabbitMq.Config;

namespace CodeMan.RabbitMq.Base.RabbitMq.Producer
{
    public class RabbitProducer : IRabbitProducer
    {
        private readonly RabbitConnection _connection;

        public RabbitProducer(RabbitConnection connection)
        {
            _connection = connection;
        }

        public void Publish(string exchange, string routingKey, IDictionary<string, object> props, string content)
        {
            var channel = _connection.GetConnection().CreateModel();
            var prop = channel.CreateBasicProperties();
            if (props.Count > 0)
            {
                var delay = props["x-delay"];
                prop.Expiration = delay.ToString();
            }
            channel.BasicPublish(exchange, routingKey, false, prop, Encoding.UTF8.GetBytes(content));
        }
    }
}