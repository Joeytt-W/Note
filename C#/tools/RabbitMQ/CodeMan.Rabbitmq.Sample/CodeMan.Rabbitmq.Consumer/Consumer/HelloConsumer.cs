using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using System;
using System.Text;
using CodeMan.Rabbitmq.Common;
using System.Collections.Generic;

namespace CodeMan.Rabbitmq.Consumer01.Consumer
{
    public class HelloConsumer
    {
        public static void HelloWorldShow()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "127.0.0.1";
            factory.Port = 5672;//5672是RabbitMQ默认的端口号
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.VirtualHost = "my_vhost";

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    /*
                     * 创建队列，声明并创建一个队列，如果队列已存在，则使用这个队列
                     * 第一个参数：队列名称ID
                     * 第二个参数：是否持久化，false对应不持久化数据，MQ停掉数据就会丢失
                     * 第三个参数：是否队列私有化，false则代表所有的消费者都可以访问，true代表只有第一次拥有它的消费者才能一直使用
                     * 第四个：是否自动删除，false代表连接停掉后不自动删除这个队列
                     * 其他额外参数为null
                     */
                    channel.QueueDeclare(RabbitConstant.QUEUE_HELLO_WORLD, true, false, false, null);
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    EventingBasicConsumer consumers = new EventingBasicConsumer(channel);
                    // 触发事件
                    consumers.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        // false只是确认签收当前的消息，设置为true的时候则代表签收该消费者所有未签收的消息
                        channel.BasicAck(ea.DeliveryTag, false);
                        Console.WriteLine($"Consumer01接收消息：{message}");
                    };
                    /*
                     * 从MQ服务器中获取数据
                     * 创建一个消息消费者
                     * 第一个参数：队列名
                     * 第二个参数：是否自动确认收到消息，false代表手动确认消息，这是MQ推荐的做法
                     * 第三个参数：要传入的IBasicConsumer接口
                     *
                     */
                    channel.BasicConsume(RabbitConstant.QUEUE_HELLO_WORLD, false, consumers);
                    Console.WriteLine("Press [Enter] to exit");
                    Console.Read();
                }
            }
        }
    }
}