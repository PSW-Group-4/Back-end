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
        private IEnumerable<BloodProduct> bloodProducts;

        [JsonInclude]
        public IEnumerable<BloodProduct> BloodProducts
        {
            get
            {
                return bloodProducts.ToList();
            }

            private set => bloodProducts = value;
        }
        public DateTime? Deadline { get; private set; }

        private Tender(IEnumerable<BloodProduct> bloodProducts, DateTime? deadline)
        {
            Id = Guid.NewGuid();
            BloodProducts = bloodProducts;
            CreatedDate = DateTime.Now;
            Deadline = deadline;
            Version = 1.0;
        }

        private Tender(IEnumerable<BloodProduct> bloodProducts)
        {
            Id = Guid.NewGuid();
            BloodProducts = bloodProducts;
            CreatedDate = DateTime.Now;
            Deadline = null;
            Version = 1.0;
        }

        public bool IsActive()
        {
            return Deadline == null || DateTime.Compare(DateTime.Now, (DateTime)Deadline) < 0;
        }

        public Tender() { }

        public static Tender Create(IEnumerable<BloodProduct> bloodProducts, DateTime? deadline)
        {
            if(deadline == null)
            {
                return new Tender(bloodProducts);
            }

            if(DateTime.Compare(DateTime.Now, (DateTime)deadline) < 0)
            {
                return new Tender(bloodProducts, deadline);
            } else
            {
                throw new DateIsBeforeTodayException();
            }
        }
    }
}
