using Confluent.Kafka;
using IntegrationLibrary.BloodRequests.Model;
using System;

namespace IntegrationAPI.Communications.Producer
{
    public class BloodRequestProducer : IProducer<BloodRequest>
    {
        private readonly ProducerConfig config = new ProducerConfig
        { BootstrapServers = "localhost:9094" };
        private readonly string topic = "blood.requests.topic";

        public void Send(string message)
        {
            var producer =
                 new ProducerBuilder<Null, string>(config).Build();
            try
            {
                producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oops, something went wrong: {e}");
            }
        }
    }
}
