using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Model
{
    public class ConsiliumRequest
    {
        public String Reason { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int Duration { get; set; }
        public bool isDoctor { get; set; }
        public List<Guid> DoctorsId { get; set; }
        public List<String> Specialities { get; set; } 
    }
}