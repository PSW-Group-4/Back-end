using HospitalLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.Dtos.Patient
{
    public class NumberOfPatientsByAgeGroup
    {
        public AgeGroup AgeGroup {get;set;}
        public int PatientCount { get; set; }

        public NumberOfPatientsByAgeGroup(AgeGroup ageGroup, int patientCount)
        {
            AgeGroup = ageGroup;
            PatientCount = patientCount;
        }
    }
}
