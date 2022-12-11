using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Symptoms.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Symptoms.Service
{
    public class SymptomService : ISymptomService
    {
        private readonly ISymptomRepository _symptomRepository;
        public SymptomService(ISymptomRepository symptomRepository)
        {
            _symptomRepository = symptomRepository;
        }
        public IEnumerable<Symptom> GetAll()
        {
            return _symptomRepository.GetAll();
        }

        public Symptom GetById(Guid id)
        {
            return _symptomRepository.GetById(id);
        }

        public Symptom Create(Symptom symptom)
        {
            return _symptomRepository.Create(symptom);
        }

        public Symptom Update(Symptom symptom)
        {
            return _symptomRepository.Update(symptom);
        }

        public void Delete(Guid id)
        {
            _symptomRepository.Delete(id);
        }
    }
}
