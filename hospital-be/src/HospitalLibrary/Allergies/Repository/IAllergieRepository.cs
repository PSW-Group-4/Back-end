using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Allergies.Repository
{
    public interface IAllergieRepository : IRepositoryBase<Allergie> {}
}
