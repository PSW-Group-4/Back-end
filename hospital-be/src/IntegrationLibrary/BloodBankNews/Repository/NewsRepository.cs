using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBankNews.Repository
{

    public class NewsRepository : INewsRepository
    {
        private readonly IntegrationDbContext _context;

        public NewsRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<News> GetAll()
        {
            return _context.News.ToList();
        }

        public IEnumerable<News> GetAllByBloodBank(BloodBank bloodBank)
        {
            return _context.News.Where(news => news.BloodBank.Id == bloodBank.Id).ToList();
        }

        public void Save(IEnumerable<News> news)
        {
            _context.News.AddRange(news);
            _context.SaveChangesAsync();
        }
    }
}
