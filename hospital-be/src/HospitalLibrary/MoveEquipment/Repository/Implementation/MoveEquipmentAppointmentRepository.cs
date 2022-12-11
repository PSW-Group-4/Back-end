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
    public class MoveEquipmentAppointmentRepository : IMoveEquipmentAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public MoveEquipmentAppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public MoveEquipmentAppointment Create(MoveEquipmentAppointment entity)
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

        public IEnumerable<MoveEquipmentAppointment> GetAll()
        {
            return _context.MoveEquipmentTasks.ToList();
        }

        public MoveEquipmentAppointment GetById(Guid id)
        {
            var result =  _context.MoveEquipmentTasks.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public MoveEquipmentAppointment Update(MoveEquipmentAppointment entity)
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