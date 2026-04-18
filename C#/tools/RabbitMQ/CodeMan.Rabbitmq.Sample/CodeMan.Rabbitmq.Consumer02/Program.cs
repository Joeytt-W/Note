using System;
using CodeMan.Rabbitmq.Consumer02.Consumer;

namespace CodeMan.Rabbitmq.Consumer02
{
    class Program
    {
        static void Main(string[] args)
        {
            // 工作队列模式
            // SmsReceive.Sender();

            // 发布订阅模式
            WeatherFanout.Weather();

            //Routing路由模式
            // WeatherDirect.Weather();

            //Routing路由模式
            // WeatherTopic.Weather();
        }
    }
}
