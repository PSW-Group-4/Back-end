using Confluent.Kafka;
using HospitalLibrary.BloodSupplies.Model;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using System.Threading;

namespace IntegrationAPI.Communications.Consumer
{
    public class BloodSupplyConsumer : IConsumer<BloodSupply>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        public BloodSupplyConsumer() { }

        public BloodSupplyConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
        }
        public BloodSupply Consume()
        {
            var consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            //BloodSupplyDto dto = JsonSerializer.Deserialize<BloodSupplyDto>(consumer.Message.Value);
            //BloodSupply bloodSupply = convertFromDto;
            //return bloodSupply;
            return new();
        }
    }
}
