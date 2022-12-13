using System;
using System.Collections.Generic;


namespace HospitalAPI.Dtos.Consilium
{
    public class ConsiliumRequestDto
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
