using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Framing;
using System.Text;

namespace Mangos.ToDo.Core.RabbitMQ
{
    public class Publisher<T> where T : class
    {
        private string exchange;
        private string type;
        public RabbitMQConnection Connection { get; set; }

        public Publisher(string exchange, string type = "topic")
        {
            this.exchange = exchange;
            this.type = type;
        }

        public void Init(bool connect = true)
        {
            if(connect)Connection.Init();
            Connection.Channel.ExchangeDeclare(exchange: exchange, type: type, durable: true);
        }

        public void Emit(T message, string routingKey)
        {
            IBasicProperties basicProperties = new BasicProperties();
            basicProperties.Type = message.GetType().AssemblyQualifiedName;
            if (Connection?.Channel?.IsOpen ?? false)
            {
                Connection.Channel.BasicPublish(exchange: exchange,
                                     routingKey: routingKey,
                                     basicProperties: basicProperties,
                                     body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message)));
            }
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
