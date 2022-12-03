using Confluent.Kafka;
using HospitalAPI.Dtos.BloodSupply;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using System.Text.Json;
using System.Threading;
using HospitalAPI.Communications.Producer;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.Common;
using IProducer = IntegrationAPI.Communications.Producer.IProducer;

namespace IntegrationAPI.Communications.Consumer.ReceivedBlood
{
    public class BloodConsumer : IConsumer<Blood>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IProducer _producer;
        public BloodConsumer() { }

        public BloodConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IProducer producer)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _producer = producer;
        }
        public Blood Consume()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            ReceivedBloodDto dto = JsonSerializer.Deserialize<ReceivedBloodDto>(consumer.Message.Value, options);
            _producer.Send(JsonSerializer.Serialize(dto), "hospital.blood.supply.topic");
            return new Blood(BloodType.FromString(dto.BloodType), dto.Amount);
        }
    }
}
