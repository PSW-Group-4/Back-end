using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace IntegrationLibrary.Tenders.Model
{
    [Table("tenders")]
    public class Tender : Entity
    {
        private IEnumerable<BloodProduct> bloodProducts;

        public IEnumerable<BloodProduct> BloodProducts
        {
            get
            {
                return bloodProducts.ToList();
            }

            private set => bloodProducts = value;
        }
        public DateTime Deadline { get; private set; }

        private Tender(IEnumerable<BloodProduct> bloodProducts, DateTime deadline)
        {
            Id = Guid.NewGuid();
            BloodProducts = bloodProducts;
            CreatedDate = DateTime.Now;
            Deadline = deadline;
            Version = 1.0;
        }

        public bool IsActive()
        {
            return DateTime.Compare(DateTime.Now, Deadline) < 0;
        }

        public static Tender Create(IEnumerable<BloodProduct> bloodProducts, DateTime deadline)
        {
            if(DateTime.Compare(DateTime.Now, deadline) < 0)
            {
                return new Tender(bloodProducts, deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }
    }
}
