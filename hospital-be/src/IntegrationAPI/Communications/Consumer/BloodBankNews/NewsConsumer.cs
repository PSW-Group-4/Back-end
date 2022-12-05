using Confluent.Kafka;
using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.BloodBankNews;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using System;
using System.Text.Json;
using System.Threading;

namespace IntegrationAPI.Communications.Consumer.BloodBankNews
{
    public class NewsConsumer : IConsumer<News>
    {
        private readonly IConsumer<Ignore, string> _consumerBuilder;
        private readonly CancellationTokenSource _cancellationToken;
        private readonly IConverter<News, NewsDto> _newsConverter;
        public NewsConsumer() { }

        public NewsConsumer(IConsumer<Ignore, string> consumerBuilder, CancellationTokenSource cancellationToken, IConverter<News, NewsDto> newsConverter)
        {
            _consumerBuilder = consumerBuilder;
            _cancellationToken = cancellationToken;
            _newsConverter = newsConverter;
        }

        public News Consume()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var consumer = _consumerBuilder.Consume(_cancellationToken.Token);
            NewsDto newsDto = JsonSerializer.Deserialize<NewsDto>(consumer.Message.Value, options);
            News news = _newsConverter.Convert(newsDto);
            return news;
        }
    }
}
