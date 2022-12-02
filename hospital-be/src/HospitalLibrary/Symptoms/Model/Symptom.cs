using System;

namespace HospitalLibrary.Symptoms.Model
{
    public class Symptom
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public void Update(Symptom symptom)
        {
            Name = symptom.Name;
        }
    }
}
