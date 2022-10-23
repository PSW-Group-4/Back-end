using HospitalLibrary.Patients.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Patients.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;

        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(Guid id)
        {
            return _context.Patients.Find(id);
        }

        public void Create(Patient Patient)
        {
            _context.Patients.Add(Patient);
            _context.SaveChanges();
        }

        public void Update(Patient Patient)
        {
            _context.Entry(Patient).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Patient Patient)
        {
            _context.Patients.Remove(Patient);
            _context.SaveChanges();
        }
    }
}
