namespace HospitalAPI.Communications.Producer
{
    public interface IProducer
    {
        void Send(string message);
    }
}