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

        public IEnumerable<News> GetArchived()
        {
            return _repository.GetArchived();
        }

        public IEnumerable<News> GetPending()
        {
            return _repository.GetPending();
        }

        public IEnumerable<News> GetPublished()
        {
            return _repository.GetPublished();
        }

        public void Save(IEnumerable<News> news)
        {
            _repository.Save(news);
        }

        public void Save(News news)
        {
            _repository.Save(news);
        }

        public News Update(News news)
        {
            return _repository.Update(news);
        }
        public News GetById(Guid id) {
            return _repository.GetById(id);
        }
    }
}