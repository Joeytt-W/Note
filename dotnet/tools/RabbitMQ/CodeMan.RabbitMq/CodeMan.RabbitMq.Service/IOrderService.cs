namespace CodeMan.RabbitMq.Service
{
    public interface IOrderService
    {
        void SendOrderMessage();
        void SendTestMessage(string message);
    }
}