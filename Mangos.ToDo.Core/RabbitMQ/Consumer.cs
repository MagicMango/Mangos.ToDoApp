using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mangos.ToDo.Core.RabbitMQ
{
    public class Consumer<T> where T: class
    {
        private string exchange;
        private string queueName;
        private string[] bindingKeys;
        public RabbitMQConnection Connection { get; set; }
        private MethodInfo JsonConvertDeserializeShell;
        private string nameSpace;

        public Consumer(string exchange, string[] bindingKeys)
        {
            this.exchange = exchange;
            this.bindingKeys = bindingKeys;
            nameSpace = typeof(T).AssemblyQualifiedName.Replace(typeof(T).FullName, "");
            JsonConvertDeserializeShell = typeof(JsonConvert)
                .GetMethods()
                .SingleOrDefault(x => x.IsGenericMethod &&
                    x.GetParameters().Select(a => a.ParameterType).SequenceEqual(new[] { typeof(string) }) &&
                    x.Name == "DeserializeObject");
        }

        public void Init(bool connect = false)
        {
            if (connect) Connection.Init();
            queueName = Connection.Channel.QueueDeclare(queue:exchange+".Queue");
            foreach (var bindingKey in bindingKeys)
            {
                Connection.Channel.QueueBind(queue: exchange + ".Queue",
                                  exchange: exchange,
                                  routingKey: bindingKey);
            }
        }

        public void Consume(Func<T, bool> cosnumerCallback, int worker = 1, bool requeueOnFailure = true)
        {
            if (worker == 0) Connection.Channel.QueueDelete(queue: exchange + ".Queue");
            for (int i = 0; i < worker; i++)
            {
                var consumer = new EventingBasicConsumer(Connection.Channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var type = Type.GetType(ea.BasicProperties.Type);
                    var DeserializeMethod = JsonConvertDeserializeShell.MakeGenericMethod(new[] { type });
                    try
                    {
                        T @event = (T)DeserializeMethod.Invoke(null, new[] { Encoding.UTF8.GetString(body) });
                        if (cosnumerCallback?.Invoke(@event) ?? false)
                        {
                            Connection.Channel.BasicAck(ea.DeliveryTag, false);
                        }
                        else
                        {
                            Connection.Channel.BasicNack(ea.DeliveryTag, false, requeueOnFailure);
                        }
                    }
                    catch
                    {
                       Connection.Channel.BasicNack(ea.DeliveryTag, false, requeueOnFailure);
                    }
                };
                Connection.Channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
            }
        }

        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
