using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Implementation
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public Equipment Create(Equipment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Equipment GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Equipment Update(Equipment entity)
        {
            throw new NotImplementedException();
        }
    }
}