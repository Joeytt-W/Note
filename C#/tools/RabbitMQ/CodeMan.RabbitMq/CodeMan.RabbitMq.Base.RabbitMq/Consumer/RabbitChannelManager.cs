using System.Collections.Generic;
using CodeMan.RabbitMq.Base.RabbitMq.Config;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CodeMan.RabbitMq.Base.RabbitMq.Consumer
{
    public class RabbitChannelManager
    {
        public RabbitConnection Connection { get; set; }

        public RabbitChannelManager(RabbitConnection connection)
        {
            this.Connection = connection;
        }

        /// <summary>
        /// 创建接收消息的通道
        /// </summary>
        /// <param name="exchangeType"></param>
        /// <param name="exchange"></param>
        /// <param name="queue"></param>
        /// <param name="routingKey"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public RabbitChannelConfig CreateReceiveChannel(string exchangeType, string exchange, string queue,
            string routingKey, IDictionary<string, object> arguments = null)
        {
            IModel model = this.CreateModel(exchangeType, exchange, queue, routingKey, arguments);
            EventingBasicConsumer consumer = this.CreateConsumer(model, queue);
            RabbitChannelConfig channel = new RabbitChannelConfig(exchangeType, exchange, queue, routingKey);
            consumer.Received += channel.Receive;
            return channel;
        }

        /// <summary>
        /// 创建一个通道 包含交换机/队列/路由，并建立绑定关系
        /// </summary>
        /// <param name="exchangeType">交换机类型:Topic、Direct、Fanout</param>
        /// <param name="exchange">交换机名称</param>
        /// <param name="queue">队列名称</param>
        /// <param name="routingKey">路由名称</param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        private IModel CreateModel(string exchangeType, string exchange, string queue, string routingKey, IDictionary<string, object> arguments)
        {
            exchangeType = string.IsNullOrEmpty(exchangeType) ? "default" : exchangeType;
            IModel model = this.Connection.GetConnection().CreateModel();
            model.BasicQos(0, 1, false);
            model.QueueDeclare(queue, true, false, false, arguments);
            model.ExchangeDeclare(exchange, exchangeType);
            model.QueueBind(queue, exchange, routingKey);
            return model;
        }

        /// <summary>
        /// 创建消费者
        /// </summary>
        /// <param name="model"></param>
        /// <param name="queue"></param>
        /// <returns></returns>
        public EventingBasicConsumer CreateConsumer(IModel model, string queue)
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(model);
            model.BasicConsume(queue, false, consumer);
            return consumer;
        }
    }
}