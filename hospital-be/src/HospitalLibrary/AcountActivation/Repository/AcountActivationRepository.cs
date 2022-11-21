using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AcountActivation.Repository
{
    public class AcountActivationRepository : IAcountActivationRepository
    {
        private readonly HospitalDbContext _context;

        public AcountActivationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<AcountActivationInfo> GetAll()
        {
            return _context.AcountActivationInfos.ToList();
        }

        public AcountActivationInfo GetById(Guid id)
        {
            var result = _context.AcountActivationInfos.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public void Delete(Guid id)
        {
            var AcountActivationInfo = GetById(id);
            _context.AcountActivationInfos.Remove(AcountActivationInfo);
            _context.SaveChanges();
        }

        public AcountActivationInfo Create(AcountActivationInfo info)
        {
            _context.AcountActivationInfos.Add(info);
            _context.SaveChanges();
            return info;
        }

        public AcountActivationInfo Update(AcountActivationInfo info)
        {
            var updatingAcountActivationInfo = _context.AcountActivationInfos.SingleOrDefault(p => p.PersonId == info.PersonId);
            if (updatingAcountActivationInfo == null)
            {
                throw new NotFoundException();
            }
            updatingAcountActivationInfo.Update(info);
            _context.SaveChanges();
            return updatingAcountActivationInfo;
        }
    }
}
