using CodeMan.RabbitMq.Entities;

namespace CodeMan.RabbitMq.Service
{
    public interface IPayService
    {
        void UpdateOrderPayState(OrderInfo orderInfo);
    }
}