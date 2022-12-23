using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos.NewsHeadlines
{
    public class NewsHeadlinesDTO 
    {
        public string Headline { get; set; }

        public NewsHeadlinesDTO(string headline)
        {
            Headline = headline;
        }
    }

}
