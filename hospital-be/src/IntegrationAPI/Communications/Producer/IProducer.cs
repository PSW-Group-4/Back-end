namespace IntegrationAPI.Communications.Producer
{
    public interface IProducer<Entity>
    {
        void Send(string message);
    }
}
