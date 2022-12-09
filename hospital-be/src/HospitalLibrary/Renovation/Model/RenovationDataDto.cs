using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.Model
{
    public class RenovationDataDto
    {
        public RoomRenovationPlan Room1 {get; set;}
        public RoomRenovationPlan Room2 {get; set;}
        public RoomRenovationPlan Room3 {get; set;}
        public HospitalLibrary.Core.Model.DateRange DateRange {get; set;}
        public String Type {get; set;}
    }
}