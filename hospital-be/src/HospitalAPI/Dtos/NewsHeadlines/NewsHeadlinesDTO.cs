using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationLibrary.BloodBanks.Model;

namespace HospitalAPI.Dtos.NewsHeadlines
{
    public class NewsHeadlinesDTO 
    {
  
        public string Title { get; private set; }
     

        public NewsHeadlinesDTO(string title)
        {
            Title = title;
        }
    }

}
