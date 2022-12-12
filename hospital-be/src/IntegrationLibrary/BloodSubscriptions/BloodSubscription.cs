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
        private List<Blood> blood;
        public List<Blood> Blood
        {
            get
            {
                return blood.ToList();
            }
            private set => blood = value;
        }
        public string BloodBankName { get; private set; }
        public int DeliveryDay { get; private set; }
        public bool ActiveStatus { get; private set; }
        public bool Sent { get; private set; }
        public BloodSubscription()
        {
            Blood = new List<Blood>();
        }
        public BloodSubscription(string bloodBankName, int deliveryDay)
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            BloodBankName = bloodBankName;
            Blood = new List<Blood>();
            if (ValidateDeliveryDay(deliveryDay)) 
            {
                DeliveryDay = deliveryDay;
            }
            else
            {
                DeliveryDay = 5;
            }
            Sent = false;
        }

        public void AddBloodType(Blood type)
        {
            this.blood.Add(type);
            MakeNotSent();

        }
        public void AddBloodType(List<Blood> types) 
        {
            foreach(Blood type in types)
            {
               this.blood.Add(type);
            }
            MakeNotSent();
        }
        public void RemoveBloodType(Blood type)
        {
            this.ValidateListLenght();
            this.blood.Remove(type);
            MakeNotSent();
        }
        public void RemoveBloodType(List<Blood> types) 
        {
            this.ValidateListLenght();
            foreach (Blood type in types)
            {
                this.blood.Remove(type);
            }
            MakeNotSent();
        }

        public void Activate()
        {
            this.ValidateListLenght();
            this.ActiveStatus = true;
            MakeNotSent();
        }
        public void Deactivate()
        {
            this.ActiveStatus = false;
            MakeNotSent();
        }

        private void ValidateListLenght()
        {
            if (this.blood.Count == 0)
            {
                throw new InvalidValueException();
            }
        }
        private Boolean ValidateDeliveryDay(int deliveryDay)
        {
            if(deliveryDay < 1 || deliveryDay > 25)
            {
                return false;
            }
            return true;
        }
        public void MakeSent()
        {
            this.Sent = true;
        }
        public void MakeNotSent()
        {
            this.Sent = false;
        }
    }
}
