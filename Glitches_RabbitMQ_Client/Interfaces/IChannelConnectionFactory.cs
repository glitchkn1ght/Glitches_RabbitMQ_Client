using RabbitMQ.Client;

namespace Glitches_RabbitMQ_Client.Interfaces
{
    public interface IChannelConnectionFactory
    {
        public IModel CreateChannel();
    }
}
