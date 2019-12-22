using RabbitMQ.Client;
using System;

namespace Mangos.ToDo.Core.RabbitMQ
{
    public class RabbitMQConnection: IDisposable
    {
        public IConnection Connection { get; set; }
        public IModel Channel { get; set; }
        private ConnectionFactory connectionFactory;


        public RabbitMQConnection()
        {
            connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
        }

        public RabbitMQConnection(string hostname = "localhost", int port = 5672, string username = "guest", string password = "guest", string virtualhost = "/")
        {
            connectionFactory = new ConnectionFactory() {
                HostName = hostname,
                Port = port,
                UserName = username,
                Password = password,
                VirtualHost = virtualhost
            };
        }

        public void Init(bool createModel = true)
        {
            if (Connection == null || !Connection.IsOpen) Connection = connectionFactory.CreateConnection();
            if(createModel) Channel = Connection.CreateModel();
        }

        public void Dispose()
        {
            Connection?.Dispose();
            Channel?.Dispose();
        }
    }
}
