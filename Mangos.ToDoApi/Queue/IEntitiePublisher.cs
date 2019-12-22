namespace Mangos.ToDoApi.Queue
{
    public interface IEntitiePublisher<T> where T: class
    {
        void Emit(T message, string routingKey);
    }
}
