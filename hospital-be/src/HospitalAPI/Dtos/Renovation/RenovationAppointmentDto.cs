using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;

namespace HospitalAPI.Dtos.Renovation
{
    public class RenovationAppointmentDto
    {
        public RoomRenovationPlanDto Room1 {get; set;}
        public RoomRenovationPlanDto Room2 {get; set;}
        public RoomRenovationPlanDto Room3 {get; set;}
        public String Type {get; set;}   
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
    }
}