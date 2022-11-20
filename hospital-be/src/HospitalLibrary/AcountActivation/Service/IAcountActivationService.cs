using HospitalLibrary.AcountActivation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AcountActivation.Service
{
    public interface IAcountActivationService
    {
        IEnumerable<AcountActivationInfo> GetAll();
        AcountActivationInfo GetById(Guid id);
        AcountActivationInfo Create (AcountActivationInfo info);
        AcountActivationInfo Update (AcountActivationInfo info);
        void Delete(Guid id);

        public void SendVerificationLinkEmail(AcountActivationInfo info);
    }
}
