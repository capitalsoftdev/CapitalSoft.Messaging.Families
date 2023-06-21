using System.Text;
using CapitalSoft.Messaging.Families.Interfaces;
using Newtonsoft.Json;

namespace CapitalSoft.Messaging.Families
{
    public class MessageProducer : IMessageProducer
    {
        private readonly IConnectionFactory _connectionFactory;

        public MessageProducer(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Publish<T>(T message, string queueName, string routeKey)
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            
            channel.QueueDeclare(queueName,  durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            
            channel.BasicPublish(exchange: "", routingKey: routeKey, false, null, body: body);
        }
    } 
}