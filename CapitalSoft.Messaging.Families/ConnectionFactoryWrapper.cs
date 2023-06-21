using RabbitMQ.Client;

namespace CapitalSoft.Messaging.Families
{
    public class ConnectionFactoryWrapper : IConnectionFactory
    {
        private readonly ConnectionFactory _connectionFactory;

        public ConnectionFactoryWrapper(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IConnection CreateConnection()
        {
            return _connectionFactory.CreateConnection();
        }
    }
}