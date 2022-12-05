using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace IntegrationLibrary.Tenders.Model
{
    [Table("tenders")]
    public class Tender : Entity
    {
        private IEnumerable<Blood> blood;

        [JsonInclude]
        public IEnumerable<Blood> Blood
        {
            get
            {
                return blood.ToList();
            }

            private set => blood = value;
        }
        public DateTime? Deadline { get; private set; }

        private Tender() { }
        private Tender(IEnumerable<Blood> blood, DateTime deadline)
        {
            Id = Guid.NewGuid();
            Blood = blood;
            CreatedDate = DateTime.Now;
            Deadline = deadline;
            Version = 1.0;
        }

        private Tender(IEnumerable<Blood> blood)
        {
            Id = Guid.NewGuid();
            Blood = blood;
            CreatedDate = DateTime.Now;
            Deadline = null;
            Version = 1.0;
        }

        public bool IsActive()
        {
            return Deadline == null || DateTime.Compare(DateTime.Now, (DateTime)Deadline) < 0;
        }

        public static Tender Create(IEnumerable<Blood> blood, DateTime? deadline)
        {
            if(deadline == null)
            {
                return new Tender(blood);
            }

            if(DateTime.Compare(DateTime.Now, (DateTime)deadline) < 0)
            {
                return new Tender(blood, (DateTime)deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }
    }
}
