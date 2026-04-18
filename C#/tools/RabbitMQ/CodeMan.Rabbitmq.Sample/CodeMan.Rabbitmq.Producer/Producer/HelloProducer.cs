using System;
using System.Collections.Generic;
using System.Text;
using CodeMan.Rabbitmq.Common;
using RabbitMQ.Client;

namespace CodeMan.Rabbitmq.Producer.Producer
{
    public class HelloProducer
    {
        public static void HelloWorldShow()
        {
            var factory = new ConnectionFactory();
            factory.HostName = "127.0.0.1";
            factory.Port = 5672;
            factory.UserName = "admin";
            factory.Password = "admin";
            factory.VirtualHost = "my_vhost";

            // 获取TCP 长连接
            using (var connection = factory.CreateConnection())
            {
                // 创建通信“通道”,相当于TCP中的虚拟连接
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    string message = "hello CodeMan 666";
                    var body = Encoding.UTF8.GetBytes(message);

                    /*
                     * exchange:交换机，暂时用不到，在进行发布订阅时才会用到
                     * 路由key
                     * 额外的设置属性
                     * 最后一个参数是要传递的消息字节数组
                     */
                    channel.BasicPublish("", RabbitConstant.QUEUE_HELLO_WORLD, null, body);
                    Console.WriteLine($"producer消息：{message}已发送");
                }
            }
        }
    }
}