using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponceConsumer : IConsumer<IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse>
    {

        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;

        public BloodSubscriptionResponceConsumer()
        {
        }

        public BloodSubscriptionResponceConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
        }

        public IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse Consume()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse response = JsonSerializer.Deserialize<IntegrationLibrary.BloodSubscriptionResponses.Model.BloodSubscriptionResponse>(consumer.Message.Value, options);
            return response;
        }
    }
}
