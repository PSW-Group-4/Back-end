using HospitalLibrary.Exceptions;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Symptoms.Repository
{
    public class SymptomRepository : ISymptomRepository
    {
        private readonly HospitalDbContext _context;
        public SymptomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Symptom> GetAll()
        {
            return _context.Symptoms.ToList();
        }

        public Symptom GetById(Guid id)
        {
            var result = _context.Symptoms.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Symptom Create(Symptom symptom)
        {
            _context.Symptoms.Add(symptom);
            _context.SaveChanges();
            return symptom;
        }
        public Symptom Update(Symptom symptom)
        {
            var updatingSymptom = _context.Symptoms.SingleOrDefault(s => s.Id == symptom.Id);
            if (updatingSymptom == null)
            {
                throw new NotFoundException();
            }

            updatingSymptom.Update(symptom);

            _context.SaveChanges();
            return updatingSymptom;
        }

        public void Delete(Guid symptomId)
        {
            var symptom = GetById(symptomId);
            _context.Symptoms.Remove(symptom);
            _context.SaveChanges();
        }
    }
}
