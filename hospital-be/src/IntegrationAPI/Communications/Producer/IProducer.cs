namespace IntegrationAPI.Communications.Producer
{
    public interface IProducer
    {
        void Send(string message, string topic);
    }
}
