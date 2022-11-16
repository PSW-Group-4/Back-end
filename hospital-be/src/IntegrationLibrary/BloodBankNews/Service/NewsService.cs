using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Repository;
using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace IntegrationLibrary.BloodBankNews.Service
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _repository;

        public NewsService(INewsRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<News> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<News> GetAllByBloodBank(BloodBank bloodBank)
        {
            return _repository.GetAllByBloodBank(bloodBank);
        }

        public void Save(IEnumerable<News> news)
        {
            _repository.Save(news);
        }

        public void Save(News news)
        {
            _repository.Save(news);
        }
        
    }
}