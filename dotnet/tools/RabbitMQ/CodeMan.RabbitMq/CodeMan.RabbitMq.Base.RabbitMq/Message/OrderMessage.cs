using CodeMan.RabbitMq.Entities;

namespace CodeMan.RabbitMq.Base.RabbitMq.Message
{
    public class OrderMessage
    {
        public OrderInfo OrderInfo { get; set; }
        public Account Account { get; set; }
    }
}