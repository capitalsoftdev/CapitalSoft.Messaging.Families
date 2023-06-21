using System;
using System.Threading.Tasks;

namespace CapitalSoft.Messaging.Families.Interfaces
{
    public interface IMessageSubscriber
    {
        Task Subscribe<T>(Func<T, Task> handler, string queueName);
    }
}