using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos.MoveEquipment
{
    public class MoveEquipmentTaskDto
    {
        public String Source {get; set;}
        public String Destination {get; set;}
        public String Equipment {get; set;}
        public DateTime Date {get; set;}
        public int Amount {get; set;}
    }
}