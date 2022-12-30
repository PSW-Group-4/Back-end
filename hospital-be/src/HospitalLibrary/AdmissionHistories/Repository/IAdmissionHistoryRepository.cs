using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.AdmissionHistories.Repository
{
    public interface IAdmissionHistoryRepository : IRepositoryBase<AdmissionHistory>
    {
    }
}
