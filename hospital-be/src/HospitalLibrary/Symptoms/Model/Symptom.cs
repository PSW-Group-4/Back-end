using HospitalLibrary.Reports.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Symptoms.Model
{
    public class Symptom
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public virtual List<Report> Reports { get; set; }
        public void Update(Symptom symptom)
        {
            Name = symptom.Name;
        }
    }
}
