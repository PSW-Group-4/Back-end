using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Room
    {
        public Guid Id {get; set;}
        public String Description {get; set;}
        public String Name {get; set;}        
        public int Number { get; set; }
        public virtual ICollection<RoomsEquipment> RoomsEquipment { get; set; }

        public Room() {}
        
        public Room(Guid id, String description, String name, int Number, ICollection<RoomsEquipment> equipment) {
            this.Id = id;
            this.Description = description;
            this.Name = name;
            this.RoomsEquipment = equipment;
        }

        public Room(RoomRenovationPlan plan) {
            this.Id = new Guid();
            this.Description = plan.Description;
            this.Name = plan.Name;
            this.Number = plan.Number;
        }

        public void Update(Room room) 
        {       
            Description = room.Description;
            Name = room.Name;
            Number = room.Number;
        }
        

        public void AddEquipment(RoomsEquipment newEquipment)
        {
            bool flag = false;
            if(this.RoomsEquipment == null) {
                this.RoomsEquipment = new List<RoomsEquipment>();
            }
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
                this.RoomsEquipment.Add(new RoomsEquipment(newEquipment.Equipment, this, newEquipment.Amount));
            }
        }

        public void AddEquipment(IEnumerable<RoomsEquipment> roomsEquipments)
        {
            foreach(RoomsEquipment roomsEquipment in roomsEquipments) {
                this.AddEquipment(roomsEquipment);
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

        public void RemoveAllEquipment() {
            this.RoomsEquipment = new List<RoomsEquipment>();
        }
    }
}