using IntegrationLibrary.BloodBankNews.Model;

namespace IntegrationAPI.Communications
{
    public interface IConsumer<Entity>
    {
        Entity Consume();
    }
}
