using Mangos.ToDo.Core.RabbitMQ;
using Microsoft.Extensions.Options;

namespace Mangos.ToDoApi.Queue
{
    public class EntitiePublisher<T> : IEntitiePublisher<T> where T: class
    {
        private Publisher<T> publisher;

        public EntitiePublisher(IOptions<RabbitMQConfig> config)
        {
            publisher = new Publisher<T>(config?.Value?.Exchange);
            publisher.Connection = new RabbitMQConnection(hostname: config?.Value?.Hostname, username: config?.Value?.Username, password: config?.Value?.Password);
            publisher.Init();
        }

        public void Emit(T message, string routingKey)
        {
            publisher.Emit(message, routingKey);
        }
    }
}
