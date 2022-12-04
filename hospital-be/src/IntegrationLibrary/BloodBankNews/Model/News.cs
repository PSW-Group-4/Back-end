using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBankNews.Model
{
    [Table("blood_bank_news")]
    public class News
    {
        public Guid Id { get; set; }
        public virtual BloodBank BloodBank { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsArchived { get; set; }
        public bool IsPublished { get; set; }
        public News() { }
        public News(Guid id, BloodBank bloodBank, string title, string body, DateTime timestamp, bool isArchived)
        {
            Id = id;
            BloodBank = bloodBank;
            Title = title;
            Body = body;
            Timestamp = timestamp;
            IsArchived = isArchived;
        }

    }
}
