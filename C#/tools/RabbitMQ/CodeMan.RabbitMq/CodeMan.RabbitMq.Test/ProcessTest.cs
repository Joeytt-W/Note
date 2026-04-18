using CodeMan.RabbitMq.Base.RabbitMq.Config;
using CodeMan.RabbitMq.Base.RabbitMq.Consumer;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Hosting;

namespace CodeMan.RabbitMq.Test
{
    public class ProcessTest : IHostedService
    {
        private readonly RabbitConnection _connection;

        public ProcessTest(RabbitConnection connection)
        {
            _connection = connection;
            Queues.Add(new QueueInfo()
            {
                ExchangeType = ExchangeType.Fanout,
                Exchange = RabbitConstant.TEST_EXCHANGE,
                Queue = RabbitConstant.TEST_QUEUE,
                RoutingKey = "",
                OnReceived = this.Receive
            });
        }

        public void Receive(RabbitMessageEntity message)
        {
            Console.WriteLine($"Test Receive Message:{message.Content}");

            message.Consumer.Model.BasicAck(message.BasicDeliver.DeliveryTag, true);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("RabbitMQ测试消息接收处理服务已启动");
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

        // public List<RabbitChannelConfig> Channels { get; set; } = new List<RabbitChannelConfig>();

        public List<QueueInfo> Queues { get; } = new List<QueueInfo>();
    }
}