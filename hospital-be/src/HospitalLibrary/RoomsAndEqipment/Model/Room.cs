using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Room
    {
        public Guid Id {get; set;}
        public String Description {get; set;}
        public String Name {get; set;}        
        public int Number { get; set; }
        public virtual ICollection<RoomsEquipment> RoomsEquipment { get; set; }

        public void Update(Room room) 
        {       
            Description = room.Description;
            Name = room.Name;
            Number = room.Number;
        }
        

        public void AddEquipment(RoomsEquipment newEquipment)
        {
            bool flag = false;
            foreach (RoomsEquipment oldeq in this.RoomsEquipment)
            {
                if(newEquipment.Equipment.Id.Equals(oldeq.Equipment.Id))
                {
                    oldeq.Amount += newEquipment.Amount;
                    flag = true;
                }
            }
            if (!flag)
            {
                this.RoomsEquipment.Add(newEquipment);
            }
        }

        public void RemoveEquipment(RoomsEquipment newEquipment)
        {
            foreach (RoomsEquipment oldeq in this.RoomsEquipment)
            {
                if (newEquipment.Equipment.Id.Equals(oldeq.Equipment.Id))
                {
                    if(oldeq.Amount > newEquipment.Amount)
                    {
                        oldeq.Amount -= newEquipment.Amount;
                    }
                    else if(oldeq.Amount == newEquipment.Amount)    
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