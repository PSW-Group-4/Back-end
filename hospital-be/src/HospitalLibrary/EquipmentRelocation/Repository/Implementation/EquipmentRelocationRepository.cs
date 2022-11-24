using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EquipmentRelocation.Repository.Implementation
{
    public class EquipmentRelocationRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentRelocationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public EquipmentRelocationDTO Create(EquipmentRelocationDTO entity)
        {
            _context.EquipmentRelocations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public IEnumerable<EquipmentRelocationDTO> GetAll()
        {
            return _context.EquipmentRelocations.ToList();
        }
    }
}
