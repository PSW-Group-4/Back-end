using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions
{
    [Table("blood_subscriptions")]
    public class BloodSubscription : Entity
    {
        public List<Blood> Blood
        {
            get
            {
                return new List<Blood>(this.Blood);
            }
            private set { }
        }
        public string BloodBankName { get; private set; }
        public bool ActiveStatus { get; private set; }
        public bool Urgent { get; private set; }
        public BloodSubscription()
        {
            Blood = new List<Blood>();
        }
        public BloodSubscription(string bloodBankName)
        {
            Id = Guid.NewGuid();
            BloodBankName = bloodBankName;
            Blood = new List<Blood>();
        }

        public void AddBloodType(Blood type)
        {
            this.Blood.Add(type);
        }
        public void AddBloodType(List<Blood> types) 
        {
            foreach(Blood type in types)
            {
               this.Blood.Add(type);
            }
        }
        public void RemoveBloodType(Blood type)
        {
            this.ValidateListLenght();
            this.Blood.Remove(type);
        }
        public void RemoveBloodType(List<Blood> types) 
        {
            this.ValidateListLenght();
            foreach (var type in types)
            {
                this.Blood.Remove(type);
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
            if (this.Blood.Count == 0)
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
