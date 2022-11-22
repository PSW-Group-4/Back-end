using HospitalLibrary.AdmissionHistories.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AdmissionHistories.Service
{
    public interface IAdmissionHistoryService
    {
        IEnumerable<AdmissionHistory> GetAll();
        AdmissionHistory GetById(Guid id);
        AdmissionHistory Create(AdmissionHistory admission);
        AdmissionHistory Update(AdmissionHistory admission);
        void Delete(Guid id);
    }
}
