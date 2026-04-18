using CodeMan.Rabbitmq.Common;
using System.Text;
using System;
using RabbitMQ.Client;

namespace CodeMan.Rabbitmq.Producer.Producer
{
    public class WeatherFanout
    {
        public static void Weather()
        {
            using (var connection = RabbitUtils.GetConnection().CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    string message = "20度";
                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish(RabbitConstant.EXCHANGE_WEATHER, "", null, body);
                    Console.WriteLine("天气信息发送成功！");
                }
            }
        }
    }
}