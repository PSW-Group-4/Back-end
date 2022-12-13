using Confluent.Kafka;
using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponceConsumer : IConsumer<BloodSubscriptionRepsponce>
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

        public BloodSubscriptionRepsponce Consume()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodSubscriptionRepsponce response = JsonSerializer.Deserialize<BloodSubscriptionRepsponce>(consumer.Message.Value, options);
            return response;
        }
    }
}
