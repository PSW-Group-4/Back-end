using HospitalLibrary.Core.Repository;
using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Medicines.Repository
{
    public interface IMedicineRepository : IRepositoryBase<Medicine>
    {
    }
}
