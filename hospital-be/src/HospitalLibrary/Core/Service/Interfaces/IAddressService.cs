using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Core.Service
{
    public interface IAddressService : ICrudService<Address>{}
}
