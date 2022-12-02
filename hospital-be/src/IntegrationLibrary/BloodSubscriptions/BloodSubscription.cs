using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions
{
    public class BloodSubscription : Entity
    {
        public List<BloodProduct> BloodProducts 
        {
            get
            {
                return new List<BloodProduct>(this.BloodProducts);
            }
            private set { }
        }
        public string BloodBankName { get; private set; }
        public bool ActiveStatus { get; private set; }
        public bool Urgent { get; private set; }
        public BloodSubscription()
        {
            BloodProducts = new List<BloodProduct>();
        }
        public BloodSubscription(string bloodBankName)
        {
            Id = Guid.NewGuid();
            BloodBankName = bloodBankName;
            BloodProducts = new List<BloodProduct>();
        }

        public void AddBloodType(BloodProduct type)
        {
            this.BloodProducts.Add(type);
        }
        public void AddBloodType(List<BloodProduct> types) 
        {
            foreach(BloodProduct type in types)
            {
               this.BloodProducts.Add(type);
            }
        }
        public void RemoveBloodType(BloodProduct type)
        {
            this.ValidateListLenght();
            this.BloodProducts.Remove(type);
        }
        public void RemoveBloodType(List<BloodProduct> types) 
        {
            this.ValidateListLenght();
            foreach (var type in types)
            {
                this.BloodProducts.Remove(type);
            }
        }

        public void Activate()
        {
            this.ValidateListLenght();
            this.ActiveStatus = true;
        }
        public void Deactivate()
        {
            this.ActiveStatus = false;
        }

        private void ValidateListLenght()
        {
            if (this.BloodProducts.Count == 0)
            {
                throw new InvalidValueException();
            }
        }
        public void MakeUrgent()
        {
            this.Urgent = true;
        }
        public void MakeNotUrgent()
        {
            this.Urgent = false;
        }
    }
}
