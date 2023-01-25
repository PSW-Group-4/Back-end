using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System;
using RabbitMQ.Client.Events;
using Confluent.Kafka;
using System.Threading;
using Newtonsoft.Json;
using HospitalAPI.RabbitMqPaket;
using Castle.Core.Resource;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsaController : ControllerBase
    {
        [HttpPost("produce")]
        public ActionResult Produce([FromBody] ContractDTO dto)
        {
            Console.WriteLine("Starting");

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "createContract",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            int i = 0;

            dto.id = "35b1196c-9581-4a32-b3f9-abab3bbea959";

            var message = dto;

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "createContract", null, body);

            Console.WriteLine($"Send message: {message}");
            i++;

            return Ok("EndProduce");
        }

        [HttpGet("consume")]
        public ActionResult Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "pswBolnica",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                //TestDto dto = JsonConvert.DeserializeObject<TestDto>(message);
                Console.WriteLine($"Recieved new message: {message}");
            };

            channel.BasicConsume(queue: "pswBolnica", autoAck: true, consumer: consumer);

            Console.WriteLine("Consuming");

            Console.ReadKey();

            return Ok();
        }
    }
}
