using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagment.Model
{
    public class Building
    {
        public Guid Id {get; set;}
        public String Name {get; set;}

        public virtual ICollection<Floor> FloorList {get; set;}
   
        public void Update(Building building) {
            Name = building.Name;
            FloorList = building.FloorList;
        }
    }
}