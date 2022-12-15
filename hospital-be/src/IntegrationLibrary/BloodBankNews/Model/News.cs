using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using IntegrationLibrary.Common;

namespace IntegrationLibrary.BloodBankNews.Model
{
    [Table("blood_bank_news")]
    public class News : Entity
    {
        public Guid Id { get; private set; }
        public virtual BloodBank BloodBank { get; private set; }
        public string Title { get; private set; }
        public string Body { get; private set; }
        public DateTime Timestamp { get; private set; }
        public bool IsArchived { get; private set; }
        public bool IsPublished { get; private set; }
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
        public void archive()
        {
            IsArchived = true;
            IsPublished = false;
        }
        public void publish()
        {
            IsPublished = true;
            IsArchived = false;
        }
        public News(string title, string body, BloodBank bloodBank, DateTime timestamp)
        {
            BloodBank = bloodBank;
            Title = title;
            Body = body;
            Timestamp = timestamp;
        }
    }
}
