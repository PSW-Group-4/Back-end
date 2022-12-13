using IntegrationLibrary.BloodBankNews.Model;

namespace IntegrationAPI.Communications.Consumer
{
    public interface IConsumer<TEntity>
    {
        TEntity Consume();
    }
}
