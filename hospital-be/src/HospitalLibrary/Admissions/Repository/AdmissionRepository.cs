using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Admissions.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly HospitalDbContext _context;

        public AdmissionRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Admission> GetAll()
        {
            return _context.Admissions.ToList();
        }

        public Admission GetById(Guid id)
        {
            var result = _context.Admissions.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Admission Create(Admission admission)
        {
            _context.Admissions.Add(admission);
            _context.SaveChanges();
            return admission;
        }

        public Admission Update(Admission admission)
        {
            var updatingAdmission = _context.Admissions.SingleOrDefault(a => a.Id == admission.Id);
            if (updatingAdmission == null)
            {
                throw new NotFoundException();
            }

            updatingAdmission.Update(admission);

            _context.SaveChanges();
            return updatingAdmission;
        }

        public void Delete(Guid admissionId)
        {
            var admission = GetById(admissionId);
            _context.Admissions.Remove(admission);
            _context.SaveChanges();
        }
        public Admission UpdateTreatment(Admission admission, Guid treatmentId)
        {
            var updatingAdmission = _context.Admissions.SingleOrDefault(a => a.Id == admission.Id);
            if (updatingAdmission == null)
            {
                throw new NotFoundException();
            }

            updatingAdmission.UpdateTreatment(treatmentId);

            _context.SaveChanges();
            return updatingAdmission;
        }
    }
}
