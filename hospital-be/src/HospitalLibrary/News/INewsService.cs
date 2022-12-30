using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.Dtos.NewsHeadlines;

namespace HospitalLibrary.News
{
    public interface INewsService
    {
        public  Task<List<NewsHeadlinesDTO>> GetAllPublishedTitlesFromIntegrationAPIAsync();
    }
}
