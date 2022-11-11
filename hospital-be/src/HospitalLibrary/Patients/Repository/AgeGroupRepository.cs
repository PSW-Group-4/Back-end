using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Patients.Repository
{
    public class AgeGroupRepository : IAgeGroupRepository
    {
        private readonly HospitalDbContext _context;

        public AgeGroupRepository(HospitalDbContext context)
        {
            _context = context;

        }


        public AgeGroup Create(AgeGroup entity)
        {
            _context.AgeGroups.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var ageGroup = GetById(id);
            _context.AgeGroups.Remove(ageGroup);
            _context.SaveChanges();
        }

        public IEnumerable<AgeGroup> GetAll()
        {
            return _context.AgeGroups.ToList();
        }

        public AgeGroup GetById(Guid id)
        {
            var result = _context.AgeGroups.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public AgeGroup Update(AgeGroup entity)
        {
            var updatingAgeGroup = _context.AgeGroups.SingleOrDefault(p => p.Id == entity.Id);
            if (updatingAgeGroup == null)
            {
                throw new NotFoundException();
            }

            updatingAgeGroup.Update(entity);

            _context.SaveChanges();
            return updatingAgeGroup;
        }
    }
}
