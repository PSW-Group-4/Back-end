using HospitalLibrary.Exceptions;
using HospitalLibrary.Reports.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Symptoms.Model
{
    public class Symptom
    {
        public Guid Id { get; private set; }
        public String Name { get; private set; }
        public virtual List<Report> Reports { get; private set; }

        public Symptom(Guid id, String name)
        {
            Id = id;
            Name = name;

            if (!IsValid())
                throw new EntityObjectValidationFailedException();
        }

        public Symptom(Guid id, String name, List<Report> reports)
        {
            Id = id;
            Name = name;
            Reports = reports;

            if (!IsValid())
                throw new EntityObjectValidationFailedException();
        }

        private bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name);
        }

        public void Update(Symptom symptom)
        {
            Name = symptom.Name;
        }
    }
}
