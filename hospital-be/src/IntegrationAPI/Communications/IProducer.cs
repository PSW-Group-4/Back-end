namespace IntegrationAPI.Communications
{
    public interface IProducer
    {
        void Send(string message);
    }
}
