using RabbitMQ.Client;

namespace CapitalSoft.Messaging.Families
{
    public interface IConnectionFactory
    {
        IConnection CreateConnection();
    }
}