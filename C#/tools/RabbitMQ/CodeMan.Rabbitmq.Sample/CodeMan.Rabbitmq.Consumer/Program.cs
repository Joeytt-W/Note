using CodeMan.Rabbitmq.Consumer01.Consumer;

namespace CodeMan.Rabbitmq.Consumer01
{
    class Program
    {
        static void Main(string[] args)
        {
            // hello world 模式消费者
            // HelloConsumer.HelloWorldShow();

            // 工作队列模式
            // SmsReceive.Sender();

            //发布订阅模式
            WeatherFanout.Weather();

            //Routing路由模式
            // WeatherDirect.Weather();

            //Topics通配符模式
            // WeatherTopic.Weather();
        }
    }
}
