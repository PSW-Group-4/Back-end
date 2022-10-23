using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Addresses.Find(id);
        }

        public void Create(Address Address)
        {
            _context.Addresses.Add(Address);
            _context.SaveChanges();
        }

        public void Update(Address Address)
        {
            _context.Entry(Address).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Address Address)
        {
            _context.Addresses.Remove(Address);
            _context.SaveChanges();
        }
    }
}
