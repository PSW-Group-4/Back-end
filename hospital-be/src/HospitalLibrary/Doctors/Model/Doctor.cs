using HospitalLibrary.Core.Model;
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

    }
}
