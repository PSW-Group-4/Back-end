using HospitalLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Repository
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(Guid id);
        void Create(Address Address);
        void Update(Address Address);
        void Delete(Address Address);
    }
}
