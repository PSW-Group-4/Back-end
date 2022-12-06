using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Symptoms.Service
{
    public interface ISymptomService
    {
        IEnumerable<Symptom> GetAll();
        Symptom GetById(Guid id);
        Symptom Create(Symptom symptom);
        Symptom Update(Symptom symptom);
        void Delete(Guid symptomId);
    }
}
