using Confluent.Kafka;
using System.Text.Json;
using System.Threading;
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
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            ReceivedBloodDto dto = JsonSerializer.Deserialize<ReceivedBloodDto>(consumer.Message.Value, options);
            _producer.Send(JsonSerializer.Serialize(dto), "hospital.blood.supply.topic");
            
            return new Blood(BloodType.FromString(dto.BloodType), dto.Amount);
        }
    }
}
