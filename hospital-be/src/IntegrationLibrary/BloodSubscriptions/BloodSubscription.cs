using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using IntegrationLibrary.Common;
using IntegrationLibrary.Exceptions;

namespace IntegrationLibrary.BloodSubscriptions
{
    [Table("blood_subscriptions")]
    public class BloodSubscription : Entity
    {
        private List<Blood> blood;

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
                DeliveryDay = deliveryDay;
            else
                DeliveryDay = 5;
            Sent = false;
        }

        public List<Blood> Blood
        {
            get => blood.ToList();
            private set => blood = value;
        }

        public string BloodBankName { get; private set; }
        public int DeliveryDay { get; private set; }
        public bool ActiveStatus { get; private set; }
        public bool Sent { get; private set; }

        public void AddBloodType(Blood type)
        {
            blood.Add(type);
            MakeNotSent();
        }

        public void AddBloodType(List<Blood> types)
        {
            foreach (Blood type in types) blood.Add(type);
            MakeNotSent();
        }

        public void RemoveBloodType(Blood type)
        {
            ValidateListLenght();
            blood.Remove(type);
            MakeNotSent();
        }

        public void RemoveBloodType(List<Blood> types)
        {
            ValidateListLenght();
            foreach (Blood type in types) blood.Remove(type);
            MakeNotSent();
        }

        public void Activate()
        {
            ValidateListLenght();
            ActiveStatus = true;
            MakeNotSent();
        }

        public void Deactivate()
        {
            ActiveStatus = false;
            MakeNotSent();
        }

        private void ValidateListLenght()
        {
            if (blood.Count == 0) throw new InvalidValueException();
        }

        private bool ValidateDeliveryDay(int deliveryDay)
        {
            if (deliveryDay < 1 || deliveryDay > 25) return false;
            return true;
        }

        public void MakeSent()
        {
            Sent = true;
        }

        public void MakeNotSent()
        {
            Sent = false;
        }
    }
}