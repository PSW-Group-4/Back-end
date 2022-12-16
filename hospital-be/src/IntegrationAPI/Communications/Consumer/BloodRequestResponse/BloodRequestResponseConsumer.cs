using Confluent.Kafka;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Service;
using System;
using System.Text.Json;
using System.Threading;

namespace IntegrationAPI.Communications.Consumer.BloodRequestResponse
{
    public class BloodRequestResponseConsumer : IConsumer<BloodRequest>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IBloodRequestService _bloodRequestService;

        public BloodRequestResponseConsumer() { }
        public BloodRequestResponseConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IBloodRequestService bloodRequestService = null)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _bloodRequestService = bloodRequestService;
        }

        public BloodRequest Consume()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodRequestResponseDto response = JsonSerializer.Deserialize<BloodRequestResponseDto>(consumer.Message.Value, options);
            BloodRequest request = _bloodRequestService.GetById(response.RequestId);
            request.Status = (BloodRequestStatus) Enum.Parse(typeof(BloodRequestStatus), response.Status);
            Console.WriteLine("Request #" + request.Id + ": " + request.Status.ToString());
            _bloodRequestService.Update(request);
            return request;
        }
    }
}
