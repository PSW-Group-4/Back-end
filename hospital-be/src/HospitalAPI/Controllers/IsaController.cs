using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System;
using RabbitMQ.Client.Events;
using Confluent.Kafka;
using System.Threading;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IsaController : ControllerBase
    {
        [HttpGet("produce")]
        public ActionResult Produce()
        {
            Console.WriteLine("Starting");

            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "letterbox",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            int i = 0;

            while(true)
            {
                var message = "This is my first Message " + i;

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "letterbox", null, body);

                Console.WriteLine($"Send message: {message}");
                i++;
                Thread.Sleep(2000);
            }

            return Ok("EndProduce");
        }

        [HttpGet("consume")]
        public ActionResult Consume()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "letterbox",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            string mess = "a";

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Recieved new message: {message}");
                mess = message;
            };

            channel.BasicConsume(queue: "letterbox", autoAck: true, consumer: consumer);

            Console.WriteLine("Consuming");

            Console.ReadKey();

            return Ok(mess);
        }
    }
}
