using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Doctors.Model
{
    public class Doctor : Person
    {
        public string LicenceNum { get; set; }
        public string Speciality { get; set; }
        public string WorkingTimeStart { get; set; }
        public string WorkingTimeEnd { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public virtual List<Consilium> Consiliums { get; set; }

        public void Update(Doctor doctor)
        {
            base.Update(doctor);
            LicenceNum = doctor.LicenceNum;
            Speciality = doctor.Speciality;
            WorkingTimeStart = doctor.WorkingTimeStart;
            WorkingTimeEnd = doctor.WorkingTimeEnd; 
        }
    }
}
