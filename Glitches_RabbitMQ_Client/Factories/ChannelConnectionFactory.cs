using Glitches_RabbitMQ_Client.Interfaces;
using RabbitMQ.Client;

namespace Glitches_RabbitMQ_Client.Factories
{
    public class ChannelConnectionFactory
    {
        private readonly IQueueConnectionFactory QConnectionFactory;

        public IModel CreateChannel()
        {
            using (var connection = this.QConnectionFactory.GetConnection())
            {
                return connection.CreateModel();
            }
        }
    }
}
