using CodeMan.Rabbitmq.Common;
using System.Text;
using System;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace CodeMan.Rabbitmq.Producer.Producer
{
    public class SmsSender
    {
        public static void Sender()
        {
            using (var connection = RabbitUtils.GetConnection().CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(RabbitConstant.QUEUE_SMS, true, false, false, null);
                    for (int i = 0; i < 100; i++)
                    {
                        Sms sms = new Sms("乘客" + i, "139000000" + i, "您的车票已预定成功");
                        string jsonSms = JsonConvert.SerializeObject(sms);
                        var body = Encoding.UTF8.GetBytes(jsonSms);
                        channel.BasicPublish("", RabbitConstant.QUEUE_SMS, null, body);
                        Console.WriteLine($"正在发送内容：{jsonSms}");
                    }
                    Console.WriteLine("发送数据成功");
                }
            }
        }
    }
}