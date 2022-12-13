using RabbitMQ.Client;

namespace Glitches_RabbitMQ_Client.Interfaces
{
    public interface IQueueConnectionFactory
    {
        public IConnection GetConnection();
    }
}
