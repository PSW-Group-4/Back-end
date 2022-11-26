using IntegrationLibrary.BloodBankNews.Model;

namespace IntegrationAPI.Communications.Consumer
{
    public interface IConsumer<Entity>
    {
        Entity Consume();
    }
}
