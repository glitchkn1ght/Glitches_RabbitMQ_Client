using Glitches_RabbitMQ_Client.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Glitches_RabbitMQ_Client.MessageConsumers
{
    public class BasicConsumer<T> : IMessageConsumer<T>
    {
        private readonly IQueueConnectionFactory QueueConnectionFactory;

        public BasicConsumer(IQueueConnectionFactory queueConnectionFactory)
        {
            this.QueueConnectionFactory = queueConnectionFactory;
        }

        public T ConsumeMessage(string queueName)
        {
            var message = default(T);
            
            using (var connection = this.QueueConnectionFactory.GetConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                   
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        message = JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(body));
                    };

                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                }
            }

            return message;
        }
    }
}
