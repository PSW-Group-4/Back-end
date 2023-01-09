using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces;
using HospitalLibrary.Settings;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.RenovationSessionAggregate.Repository.Implementation
{
    public class RenovationSessionEventRepository : IRenovationSessionEventRepository
    {
         private readonly HospitalDbContext _context;

        public RenovationSessionEventRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public RenovationSessionEvent Create(RenovationSessionEvent entity)
        {
            _context.RenovationSessionEvents.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.RenovationSessionEvents.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<RenovationSessionEvent> GetAll()
        {
            return _context.RenovationSessionEvents.ToList();
        }

        public RenovationSessionEvent GetById(Guid id)
        {
            var result =  _context.RenovationSessionEvents.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        // Does nothing, events cant be updates. Left here to fill implementation requirements
        public RenovationSessionEvent Update(RenovationSessionEvent entity)
        {
            var updatingEntity = _context.RenovationSessionEvents.SingleOrDefault(e => e.Id == entity.Id);
            if (updatingEntity == null)
            {
                throw new NotFoundException();
            }
            
            _context.SaveChanges();
            return updatingEntity;
        }
    }
}