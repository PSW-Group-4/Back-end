using System;
using Confluent.Kafka;

namespace IntegrationAPI.Communications.Producer
{
    public class Producer : IProducer
    {
        private readonly ProducerConfig config = new ProducerConfig
            { BootstrapServers = "localhost:9094" };

        public void Send(string message, string topic)
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