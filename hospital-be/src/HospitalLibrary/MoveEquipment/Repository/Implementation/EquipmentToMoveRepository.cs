using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;
using HospitalLibrary.MoveEquipment.Repository.Interfaces;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.MoveEquipment.Repository.Implementation
{
    public class EquipmentToMoveRepository : IEquipmentToMoveRepository
    {
        private readonly HospitalDbContext _context;

        public EquipmentToMoveRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public EquipmentToMove Create(EquipmentToMove entity)
        {
            _context.EquipmentToMoves.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.EquipmentToMoves.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<EquipmentToMove> GetAll()
        {
            return _context.EquipmentToMoves.ToList();
        }

        public EquipmentToMove GetById(Guid id)
        {
            var result =  _context.EquipmentToMoves.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public EquipmentToMove Update(EquipmentToMove entity)
        {
            var updatingEntity = _context.EquipmentToMoves.SingleOrDefault(e => e.Id == entity.Id);
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