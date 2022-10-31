using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Core.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HospitalDbContext _context;

        public AddressRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(Guid id)
        {
            var result = _context.Addresses.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Address Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
            return address;
        }

        public Address Update(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            _context.SaveChanges();
            return address;
        }

        public void Delete(Guid addressId)
        {
            var address = GetById(addressId);
            _context.Addresses.Remove(address);
            _context.SaveChanges();
        }
    }
}
