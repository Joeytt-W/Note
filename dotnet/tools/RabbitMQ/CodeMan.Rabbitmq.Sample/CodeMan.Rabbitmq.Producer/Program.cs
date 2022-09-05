using System;
using CodeMan.Rabbitmq.Producer.Producer;

namespace CodeMan.Rabbitmq.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            // hello world 模式消费者
            // HelloProducer.HelloWorldShow();

            // 工作队列模式
            // SmsSender.Sender();

            //发布订阅模式
            WeatherFanout.Weather();

            //Routing路由模式
            // WeatherDirect.Weather();

            //Topic通配符模式
            // WeatherTopic.Weather();
        }
    }
}
