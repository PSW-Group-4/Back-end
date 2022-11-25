using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class DoctorRoom : Room
    {
        public virtual ICollection<RoomsEquipment> RoomsEquipment { get; set; }
        public void Update(DoctorRoom room)
        {
            base.Update(room);            
        }

        public void addEquipment(ICollection<RoomsEquipment> newEquipment)
        {
            foreach (RoomsEquipment neweq in newEquipment)
            {
                bool flag = false;
                foreach (RoomsEquipment oldeq in this.RoomsEquipment)
                {
                    if(neweq.Equipment.Id.Equals(oldeq.Equipment.Id))
                    {
                        oldeq.Amount += neweq.Amount;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    this.RoomsEquipment.Add(neweq);
                }
            }
        }

        public void RemoveEquipment(ICollection<RoomsEquipment> newEquipment)
        {
            foreach (RoomsEquipment neweq in newEquipment)
            {
                foreach (RoomsEquipment oldeq in this.RoomsEquipment)
                {
                    if (neweq.Equipment.Id.Equals(oldeq.Equipment.Id))
                    {
                        if(oldeq.Amount > neweq.Amount)
                        {
                            oldeq.Amount -= neweq.Amount;
                        }
                        else if(oldeq.Amount == neweq.Amount)    
                        {
                            this.RoomsEquipment.Remove(oldeq);
                        }
                        else
                        {
                            return;
                        }
                        
                    }
                }
            }
        }
    }
}
