using CodeMan.RabbitMq.Base.RabbitMq.Config;
using CodeMan.RabbitMq.Base.RabbitMq.Consumer;
using CodeMan.RabbitMq.Base.RabbitMq.Message;
using CodeMan.RabbitMq.Service;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Hosting;

namespace CodeMan.RabbitMq.Pay.Timeout
{
    public class ProcessPayTimeout : IHostedService
    {
        private readonly RabbitConnection _connection;
        private readonly IPayService _payService;

        public ProcessPayTimeout(RabbitConnection connection, IPayService payService)
        {
            _connection = connection;
            _payService = payService;
            Queues.Add(new QueueInfo()
            {
                ExchangeType = ExchangeType.Direct,
                Exchange = RabbitConstant.DEAD_LETTER_EXCHANGE,
                Queue = RabbitConstant.DEAD_LETTER_QUEUE,
                RoutingKey = RabbitConstant.DEAD_LETTER_ROUTING_KEY,
                OnReceived = this.Receive
            });
        }

        public void Receive(RabbitMessageEntity message)
        {
            Console.WriteLine($"Pay Timeout Receive Message:{message.Content}");
            OrderMessage orderMessage = JsonConvert.DeserializeObject<OrderMessage>(message.Content);
            orderMessage.OrderInfo.Status = 2;
            Console.WriteLine("超时未支付");
            _payService.UpdateOrderPayState(orderMessage.OrderInfo);
            message.Consumer.Model.BasicAck(message.BasicDeliver.DeliveryTag, true);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("RabbitMQ超时支付处理服务已启动");
            RabbitChannelManager channelManager = new RabbitChannelManager(_connection);
            foreach (var queueInfo in Queues)
            {
                RabbitChannelConfig channel = channelManager.CreateReceiveChannel(queueInfo.ExchangeType,
                    queueInfo.Exchange, queueInfo.Queue, queueInfo.RoutingKey);
                channel.OnReceivedCallback = queueInfo.OnReceived;
                //this.Channels.Add(channel);
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public List<RabbitChannelConfig> Channels { get; set; } = new List<RabbitChannelConfig>();

        public List<QueueInfo> Queues { get; } = new List<QueueInfo>();
    }
}