using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;
using HospitalLibrary.Vacations.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Vacations.Repository
{
    public class VacationRepository : IVacationRepository
    {
        private readonly HospitalDbContext _context;

        public VacationRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Vacation> GetAll()
        {
            return _context.Vacations.ToList();
        }

        public Vacation GetById(Guid id)
        {
            var result = _context.Vacations.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Vacation Update(Vacation entity)
        {
            throw new NotImplementedException();
        }
        public Vacation Create(Vacation entity)
        {
            _context.Vacations.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            _context.Vacations.Remove(GetById(id));
            _context.SaveChanges();
        }
    }
}
