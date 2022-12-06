using IntegrationAPI.Communications.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting
{
    public class BloodRequestProducerTest
    {
        [Fact]
        public void Kafka_Is_Up_And_Message_Is_Sent()
        {
            Producer producer = new();

            var exception = Record.Exception(() => producer.Send("Hello!", "random.topic"));

            Assert.Null(exception);
        }
    }
}
