using Glitches_RabbitMQ_Client.Config;
using Glitches_RabbitMQ_Client.Interfaces;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Glitches_RabbitMQ_Client.Factories
{
    public class QueueConnectionFactory : IQueueConnectionFactory
    {
        private readonly RabbitMqSettings RabbitMqSettings;

        public QueueConnectionFactory(IOptions<RabbitMqSettings> rabbitMqSettings)
        {
            RabbitMqSettings = rabbitMqSettings.Value;
        }

        public IConnection GetConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.HostName = RabbitMqSettings.HostName;
            connectionFactory.UserName = RabbitMqSettings.Username;
            connectionFactory.Password = RabbitMqSettings.Password;

            return connectionFactory.CreateConnection();
        }
    }
}
