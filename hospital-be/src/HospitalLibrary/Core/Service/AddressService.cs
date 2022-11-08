using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public Address GetById(Guid id)
        {
            return _addressRepository.GetById(id);
        }

        public Address Create(Address address)
        {
            return _addressRepository.Create(address);
        }

        public Address Update(Address address)
        {
            return _addressRepository.Update(address);
        }

        public void Delete(Guid addressId)
        {
            _addressRepository.Delete(addressId);
        }
    }
}
