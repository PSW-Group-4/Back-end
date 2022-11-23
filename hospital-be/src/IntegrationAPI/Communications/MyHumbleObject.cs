using Confluent.Kafka;
using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using System;
using System.Text.Json;
using System.Threading;

namespace IntegrationAPI.Communications
{
    public class MyHumbleObject
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly INewsService _newsService;
        private readonly IConverter<News, NewsDto> _newsConverter;
        public MyHumbleObject() { }

        public MyHumbleObject(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, INewsService newsService, IConverter<News, NewsDto> newsConverter)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _newsService = newsService;
            _newsConverter = newsConverter;
        }

        public void DoStuff()
        {
            var consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            NewsDto newsDto = JsonSerializer.Deserialize<NewsDto>(consumer.Message.Value);
            _newsService.Save(_newsConverter.Convert(newsDto));
            Console.WriteLine("Consumed: " + newsDto);
        }
    }
}
