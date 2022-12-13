using Glitches_RabbitMQ_Client.Factories;
using Glitches_RabbitMQ_Client.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace Glitches_RabbitMQ_Client.MessageProducers
{
    public class BasicProducer : IMessageProducer
    {
        private readonly IChannelConnectionFactory ChannelConnectionFactory;

        public BasicProducer(IChannelConnectionFactory channelConnectionFactory)
        {
            this.ChannelConnectionFactory = channelConnectionFactory;
        }

        public void SendMessage<T>(string queueName, T message)
        {
            using (var channel = ChannelConnectionFactory.CreateChannel())
            {
                channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: "hello", body: body);
            }
        }
    }
}
