using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagment.Model
{
    public class Building
    {
        public Guid Guid {get; set;}
        public String Name {get; set;}

        public List<Floor> FloorList {get; set;}
    }
}