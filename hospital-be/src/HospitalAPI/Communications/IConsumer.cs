namespace HospitalAPI.Communications.Consumer
{
    public interface IConsumer<Entity>
    {
        Entity Consume();
    }
}