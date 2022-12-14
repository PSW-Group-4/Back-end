using System;
using System.Text.Json;
using System.Threading;
using Confluent.Kafka;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationAPI.Dtos.BloodSubscriptionResponse;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.BloodSubscriptionResponses.Service;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;

namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponseConsumer : IConsumer<BloodSubscriptionResponseDto>
    {

        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IProducer _producer;
        private readonly IBloodSubscriptionService _subscriptionService;
        private readonly IBloodSubscriptionResponseService _responseService;
        public BloodSubscriptionResponseConsumer()
        {
        }

        public BloodSubscriptionResponseConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IProducer producer, IBloodSubscriptionService subscriptionService, IBloodSubscriptionResponseService responseService)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _producer = producer;
            _subscriptionService = subscriptionService;
            _responseService = responseService;

        }

        public BloodSubscriptionResponseDto Consume()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodSubscriptionResponseDto response = JsonSerializer.Deserialize<BloodSubscriptionResponseDto>(consumer.Message.Value, options);
            if (response != null)
            {
                BloodSubscription subscription = _subscriptionService.GetById(new Guid(response.SubscriptionId));
                if (subscription == null)
                {
                    throw new NotFoundException();
                }
                _responseService.Create(BloodSubscriptionResponseConverter.Convert(subscription, response));
                if (response.MessageString.Split(":")[0].Equals("DELIVERY-SUCCESS"))
                {
                    BloodType typeFromResponse = BloodType.FromString(response.MessageString.Split(":")[1].Replace('_', ' '));
                    foreach (Blood blood in subscription.Blood)
                    {
                        if (typeFromResponse != null)
                        {
                            if (typeFromResponse.Equals(blood.BloodType))
                            {
                                ReceivedBloodDto dto = new ReceivedBloodDto(blood.BloodType.ToString(), blood.Amount);
                                _producer.Send(JsonSerializer.Serialize(dto), "hospital.blood.supply.topic");
                            }
                        }
                    }
                }
            }
            return response;
        }
    }
}
