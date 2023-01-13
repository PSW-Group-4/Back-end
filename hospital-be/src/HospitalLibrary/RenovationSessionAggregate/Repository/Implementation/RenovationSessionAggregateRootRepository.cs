using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Settings;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RenovationSessionAggregate.Repository.Interfaces;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace HospitalLibrary.RenovationSessionAggregate.Repository.Implementation
{
    public class RenovationSessionAggregateRootRepository : IRenovationSessionAggregateRootRepository
    {
        private readonly HospitalDbContext _context;

        public RenovationSessionAggregateRootRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public RenovationSessionAggregateRoot Create(RenovationSessionAggregateRoot entity)
        {
            _context.RenovationSessionAggregateRoots.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.RenovationSessionAggregateRoots.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<RenovationSessionAggregateRoot> GetAll()
        {
            return _context.RenovationSessionAggregateRoots.ToList();
        }

        public RenovationSessionAggregateRoot GetById(Guid id)
        {
            var result =  _context.RenovationSessionAggregateRoots.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public RenovationSessionAggregateRoot Update(RenovationSessionAggregateRoot entity)
        {
            var updatingEntity = _context.RenovationSessionAggregateRoots.SingleOrDefault(e => e.Id == entity.Id);
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