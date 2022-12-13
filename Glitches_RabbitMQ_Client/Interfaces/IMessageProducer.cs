using System;
using System.Collections.Generic;
using System.Text;

namespace Glitches_RabbitMQ_Client.Interfaces
{
    public interface IMessageProducer
    {
        public void SendMessage<T>(string queueName, T message);
    }
}
