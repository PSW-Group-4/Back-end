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
    public class MoveEquipmentTaskRepository : IMoveEquipmentTaskRepository
    {
          private readonly HospitalDbContext _context;

        public MoveEquipmentTaskRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public MoveEquipmentTask Create(MoveEquipmentTask entity)
        {
            _context.MoveEquipmentTasks.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.MoveEquipmentTasks.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<MoveEquipmentTask> GetAll()
        {
            return _context.MoveEquipmentTasks.ToList();
        }

        public MoveEquipmentTask GetById(Guid id)
        {
            var result =  _context.MoveEquipmentTasks.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public MoveEquipmentTask Update(MoveEquipmentTask entity)
        {
            var updatingEntity = _context.MoveEquipmentTasks.SingleOrDefault(e => e.Id == entity.Id);
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