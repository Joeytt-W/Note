using CodeMan.Rabbitmq.Common;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;

namespace CodeMan.Rabbitmq.Consumer01.Consumer
{
    public class SmsReceive
    {
        public static void Sender()
        {
            var connection = RabbitUtils.GetConnection().CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare(RabbitConstant.QUEUE_SMS, true, false, false, null);
            // 如果不写basicQos(1)，则自动MQ会将所有请求平均发送给所有消费者
            // basicQos，MQ不再对消费者一次发送多个请求，而是消费者处理完一个消息后(确认后)，再从队列中获取一个新的
            channel.BasicQos(0, 1, false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Thread.Sleep(30);
                Console.WriteLine($"SmsSender01-发送短信成功：{message}");
                channel.BasicAck(ea.DeliveryTag, false);
            };

            channel.BasicConsume(RabbitConstant.QUEUE_SMS, false, consumer);
            Console.WriteLine("Press [Enter] to exit");
            Console.Read();
        }
    }
}