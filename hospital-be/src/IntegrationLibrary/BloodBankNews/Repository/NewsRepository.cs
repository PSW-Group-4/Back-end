using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Exceptions;
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

        public void Save(News news)
        {
            _context.News.Add(news);
            _context.SaveChangesAsync();
        }
        public IEnumerable<News> GetArchived()
        { 
           return _context.News.Where(n => n.IsArchived == true);
        }
        public IEnumerable<News> GetPublished()
        {
            return _context.News.Where(n => n.IsPublished == true);
        }
        public IEnumerable<News> GetPending() 
        {
            return _context.News.Where(n =>( (n.IsArchived == false) && (n.IsPublished == false)));
        }
        public News Update(News news) {
            var local = _context.Set<News>()
         .Local
         .FirstOrDefault(entry => entry.Id.Equals(news.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(news).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return news;
        }
        public News GetById(Guid id) {
            News news = _context.News.Find(id);
            if (news == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return news;
            }
        }
    }
}
