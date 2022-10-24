using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Patients.Model
{
    public class Patient : Person
    {
        public string Lbo { get; set; }
        public bool Blocked { get; set; }


        public void Update(Patient patient)
        {
          base.Update(patient);
          Lbo = patient.Lbo;
          Blocked = patient.Blocked;
        }
    }
}
