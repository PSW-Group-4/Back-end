using Confluent.Kafka;
using HospitalAPI.Dtos.BloodSupply;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using System.Text.Json;
using System.Threading;

namespace IntegrationAPI.Communications.Consumer.BankBloodSupply
{
    public class BloodSupplyConsumer : IConsumer<BloodSupply>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IBloodSupplyService _bloodSupplyService;
        public BloodSupplyConsumer() { }

        public BloodSupplyConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IBloodSupplyService bloodSupplyService)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _bloodSupplyService = bloodSupplyService;
        }
        public BloodSupply Consume()
        {
            var consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodSupplyDto dto = JsonSerializer.Deserialize<BloodSupplyDto>(consumer.Message.Value);
            return _bloodSupplyService.UpdateByType(dto.Type, dto.Amount);
        }
    }
}
