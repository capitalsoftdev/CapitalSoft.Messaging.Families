namespace CapitalSoft.Messaging.Families.Interfaces
{
    public interface IMessageProducer
    {
        void Publish<T>(T message,  string queueName, string routeKey);
    }
}