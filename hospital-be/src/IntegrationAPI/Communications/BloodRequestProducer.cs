using Confluent.Kafka;
using System;

namespace IntegrationAPI.Communications
{
    public class BloodRequestProducer : IProducer
    {
        private readonly ProducerConfig config = new ProducerConfig
        { BootstrapServers = "localhost:9094" };
        private readonly string topic = "blood.requests.topic";

        public void Send(string message)
        {
            using (var producer =
                 new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
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
}
