using CapitalSoft.Messaging.Families.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace CapitalSoft.Messaging.Families
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRabbitMq(
            this IServiceCollection services,
            ConnectionFactory connectionFactory)
        {
            services.AddSingleton<IConnectionFactory>(_ => new ConnectionFactoryWrapper(connectionFactory));
            
            services.AddScoped<IMessageProducer, MessageProducer>();
            
            services.AddSingleton<IMessageSubscriber, MessageSubscriber>();
            
            return services;
        }
    }
}