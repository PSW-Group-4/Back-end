using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AdmissionHistories.Repository
{
    public class AdmissionHistoryRepository : IAdmissionHistoryRepository
    {
        private readonly HospitalDbContext _context;

        public AdmissionHistoryRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public AdmissionHistory Create(AdmissionHistory entity)
        {
            _context.AdmissionHistories.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdmissionHistory> GetAll()
        {
            return _context.AdmissionHistories.ToList();
        }

        public AdmissionHistory GetById(Guid id)
        {
            var result = _context.AdmissionHistories.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public AdmissionHistory Update(AdmissionHistory entity)
        {
            throw new NotImplementedException();
        }
    }
}
