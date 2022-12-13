using System;
using System.Collections.Generic;
using System.Text;

namespace Glitches_RabbitMQ_Client.Interfaces
{
    public interface IMessageConsumer<T>
    {
        public T ConsumeMessage(string queueName);
    }
}
