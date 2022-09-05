using CodeMan.Rabbitmq.Common;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Text;

namespace CodeMan.Rabbitmq.Consumer01.Consumer
{
    public class WeatherFanout
    {
        public static void Weather()
        {
            using (var connection = RabbitUtils.GetConnection().CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(RabbitConstant.EXCHANGE_WEATHER, ExchangeType.Fanout);
                    // 声明队列信息
                    channel.QueueDeclare(RabbitConstant.QUEUE_BAIDU, true, false, false, null);
                    /*
                     * queueBind 用于将队列与交换机绑定
                     * 参数1：队列名
                     * 参数2：交换机名
                     * 参数3：路由Key(暂时用不到)
                     */
                    channel.QueueBind(RabbitConstant.QUEUE_BAIDU, RabbitConstant.EXCHANGE_WEATHER, "");

                    channel.BasicQos(0, 1, false);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += ((model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine($"百度收到的气象信息：{message}");
                        channel.BasicAck(ea.DeliveryTag, false);
                    });

                    channel.BasicConsume(RabbitConstant.QUEUE_BAIDU, false, consumer);
                    Console.WriteLine("Press [Enter] to exit");
                    Console.Read();
                }
            }
        }
    }
}