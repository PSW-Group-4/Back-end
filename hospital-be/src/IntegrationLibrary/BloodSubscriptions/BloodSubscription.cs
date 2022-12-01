using IntegrationLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodSubscriptions
{
    public class BloodSubscription : Entity
    {
        public List<BloodType> BloodTypes 
        {
            get
            {
                return new List<BloodType>(this.BloodTypes);
            }
            private set { }
        }
        public string BloodBankName { get; private set; }
        
        public BloodSubscription()
        {
            BloodTypes = new List<BloodType>();
        }
        public BloodSubscription(string bloodBankName)
        {
            Id = Guid.NewGuid();
            BloodBankName = bloodBankName;
            BloodTypes = new List<BloodType>();
        }

        public void addBloodType(BloodType type)
        {

        }
        public void addBloodType(List<BloodType> types) { }
        public void removeBloodType(BloodType type)
        {

        }
        public void removeBloodType(List<BloodType> types) { }
    }
}
