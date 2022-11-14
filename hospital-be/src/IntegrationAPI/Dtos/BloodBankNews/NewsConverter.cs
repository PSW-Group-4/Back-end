using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Service;
using System;

namespace IntegrationAPI.Dtos.BloodBankNews
{
    public class NewsConverter : IConverter<News, NewsDto>
    {
        private readonly IBloodBankService _bloodBankService;

        public NewsConverter(IBloodBankService bloodBankService)
        {
            _bloodBankService = bloodBankService;
        }

        public NewsDto Convert(News entity)
        {
            NewsDto newsDto = new()
            {
                title = entity.Title,
                body = entity.Body,
                bloodBank = entity.BloodBank.Name,
                timestamp = entity.Timestamp.ToString(),
                id = entity.Id
            };
            return newsDto;

        }

        public News Convert(NewsDto dto)
        {
            News news = new()
            {
                Title = dto.title,
                Body = dto.body,
                BloodBank = _bloodBankService.GetByName(dto.bloodBank),
                Timestamp = DateTime.Parse(dto.timestamp)
            };
            return news;
        }
    }
}
