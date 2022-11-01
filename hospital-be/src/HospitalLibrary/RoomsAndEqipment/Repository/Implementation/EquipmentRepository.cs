using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;
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
            _context.Equipments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Equipments.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Equipment> GetAll()
        {
            return _context.Equipments.ToList();
        }

        public Equipment GetById(Guid id)
        {
            var result =  _context.Equipments.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Equipment Update(Equipment entity)
        {
            var updatingEntity = _context.Equipments.SingleOrDefault(e => e.Id == entity.Id);
            if (updatingEntity == null)
            {
                throw new NotFoundException();
            }
            
            updatingEntity.Update(entity);
            
            _context.SaveChanges();
            return updatingEntity;
        }
    }
}