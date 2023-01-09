using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Repository.Interfaces;
using HospitalLibrary.Settings;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Renovation.Repository.Implementation
{
    public class RenovationAppointmentRepository : IRenovationAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public RenovationAppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public RenovationAppointment Create(RenovationAppointment entity)
        {
            _context.RenovationAppointments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.RenovationAppointments.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<RenovationAppointment> GetAll()
        {
            return _context.RenovationAppointments.ToList();
        }

        public RenovationAppointment GetById(Guid id)
        {
            var result =  _context.RenovationAppointments.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public RenovationAppointment Update(RenovationAppointment entity)
        {
            var updatingEntity = _context.RenovationAppointments.SingleOrDefault(e => e.Id == entity.Id);
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