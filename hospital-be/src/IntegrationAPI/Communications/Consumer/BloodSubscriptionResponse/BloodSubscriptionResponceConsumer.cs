using Confluent.Kafka;
using IntegrationAPI.Dtos.BloodSubscription;
using IntegrationAPI.Dtos.BloodSubscriptionResponce;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.BloodSubscriptionReponces.Model;
using IntegrationLibrary.BloodSubscriptionReponces.Service;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.BloodSubscriptions.Service;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using IProducer = IntegrationAPI.Communications.Producer.IProducer;


namespace IntegrationAPI.Communications.Consumer.BloodSubscriptionResponse
{
    public class BloodSubscriptionResponceConsumer : IConsumer<BloodSubscriptionResponceDto>
    {

        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IProducer _producer;
        private readonly IBloodSubscriptionService subscriptionService;
        private readonly IBloodSubscriptionResponceService responceService;
        public BloodSubscriptionResponceConsumer()
        {
        }

        public BloodSubscriptionResponceConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IProducer producer, IBloodSubscriptionService subscriptionService, IBloodSubscriptionResponceService responceService)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _producer = producer;
            this.subscriptionService = subscriptionService;
            this.responceService = responceService;

        }

        public BloodSubscriptionResponceDto Consume()
        {
            JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };
            ConsumeResult<Ignore, string> consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            BloodSubscriptionResponceDto response = JsonSerializer.Deserialize<BloodSubscriptionResponceDto>(consumer.Message.Value, options);
            if (response != null)
            {
                BloodSubscription subscription = subscriptionService.GetById(new Guid(response.SubscriptionId));
                if (subscription == null)
                {
                    throw new NotFoundException();
                }
                responceService.Create(BloodSubscriptionResponceConverter.Convert(subscription, response));
                //"DELIVERY-SUCCESS:A_POSITIVE"
                if (response.MessageString.Split(":")[0].Equals("DELIVERY - SUCCESS"))
                {
                    //TODO: fetch subscription, get its blood type and amount  
                    //and update hospital blood supply

                    BloodType typeFromResponce = BloodType.FromString(response.MessageString.Split(":")[1].Replace('_', ' '));
                    //"DELIVERY-SUCCESS:A POSITIVE"
                    foreach (Blood blood in subscription.Blood)
                    {
                        if (typeFromResponce != null)
                        {
                            if (typeFromResponce.Equals(blood.BloodType))
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
