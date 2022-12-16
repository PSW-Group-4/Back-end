using System;
using System.Text.Json;
using System.Threading;
using Confluent.Kafka;
using HospitalAPI.Communications.Consumer;
using HospitalAPI.Dtos.BloodSupply;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BloodSupplies.Service;

namespace HospitalAPI.Communications
{
    public class BloodSupplyStateConsumer : IConsumer<BloodSupply>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IBloodSupplyService _bloodSupplyService;
        public BloodSupplyStateConsumer() { }

        public BloodSupplyStateConsumer(Confluent.Kafka.IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IBloodSupplyService bloodSupplyService)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _bloodSupplyService = bloodSupplyService;
        }
        public BloodSupply Consume()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodSupplyDto dto = JsonSerializer.Deserialize<BloodSupplyDto>(consumer.Message.Value, options);
            Console.WriteLine("Hospital received blood: " + dto.BloodType.ToString() + ", " + dto.Amount + "ml");
            return _bloodSupplyService.UpdateByType(dto.BloodType, dto.Amount);
        }
    }
}