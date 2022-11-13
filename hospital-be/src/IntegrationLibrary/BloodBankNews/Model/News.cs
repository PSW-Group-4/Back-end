using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBankNews.Model
{
    public class News
    {
        public Guid Id { get; set; }
        public BloodBank BloodBank { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime Timestamp { get; set; }

    }
}
