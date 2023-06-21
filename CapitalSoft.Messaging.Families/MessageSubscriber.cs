using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapitalSoft.Messaging.Families.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CapitalSoft.Messaging.Families
{
    public class MessageSubscriber : IMessageSubscriber
    {
        private readonly IModel _channel;
        
        public MessageSubscriber(
            IConnectionFactory connectionFactory)
        {
            IConnection connection = connectionFactory.CreateConnection();
            _channel = connection.CreateModel();
        }
        
        public Task Subscribe<T>(Func<T,Task> handler, string queueName)
        {
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var messageObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(message);
                await handler(messageObject);
            };

            _channel.BasicConsume(queueName, true, consumer);
            return Task.CompletedTask;
        }
    }
}