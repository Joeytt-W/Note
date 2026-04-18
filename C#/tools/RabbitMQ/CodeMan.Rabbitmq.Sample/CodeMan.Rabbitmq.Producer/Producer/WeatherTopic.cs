using CodeMan.Rabbitmq.Common;
using System.Collections.Generic;
using System.Text;
using System;
using RabbitMQ.Client;

namespace CodeMan.Rabbitmq.Producer.Producer
{
    public class WeatherTopic
    {
        public static void Weather()
        {
            Dictionary<string, string> area = new Dictionary<string, string>();
            area.Add("china.hunan.changsha.20210525", "中国湖南长沙20210525天气数据");
            area.Add("china.hubei.wuhan.20210525", "中国湖北武汉20210525天气数据");
            area.Add("china.hubei.xiangyang.20210525", "中国湖北襄阳20210525天气数据");
            area.Add("us.cal.lsj.20210525", "美国加州洛杉矶20210525天气数据");

            using (var connection = RabbitUtils.GetConnection().CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    foreach (var item in area)
                    {
                        channel.BasicPublish(RabbitConstant.EXCHANGE_WEATHER_TOPIC, item.Key,
                            null, Encoding.UTF8.GetBytes(item.Value));
                    }

                    Console.WriteLine("气象信息发送成功！");
                }
            }
        }
    }
}