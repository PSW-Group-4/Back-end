using HospitalLibrary.AcountActivation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AcountActivation.Repository
{
    public interface IAcountActivationRepository
    {
        public AcountActivationInfo GetById(Guid id);
        public void Delete (Guid id);
        public AcountActivationInfo Create(AcountActivationInfo info);
        public AcountActivationInfo Update(AcountActivationInfo info);
        public IEnumerable<AcountActivationInfo> GetAll();
    }
}
