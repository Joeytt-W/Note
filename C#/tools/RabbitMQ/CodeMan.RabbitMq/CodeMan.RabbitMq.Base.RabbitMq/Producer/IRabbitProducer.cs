using System.Collections.Generic;

namespace CodeMan.RabbitMq.Base.RabbitMq.Producer
{
    public interface IRabbitProducer
    {
        public void Publish(string exchange, string routingKey, IDictionary<string, object> props, string content);
    }
}