using HospitalLibrary.Core.Repository;
using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Allergies.Repository
{
    public class AllergieRepository : IAllergieRepository
    {
        private readonly HospitalDbContext _context;

        public AllergieRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Allergie> GetAll()
        {
            return _context.Allergies.ToList();
        }

        public Allergie GetById(Guid id)
        {
            var result =  _context.Allergies.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return  result;
        }

        public Allergie Create(Allergie allergie)
        {
            _context.Allergies.Add(allergie);
            _context.SaveChanges();
            return allergie;
        }

        public Allergie Update(Allergie allergie)
        {
            var updatingAllergie = _context.Allergies.SingleOrDefault(p => p.Id == allergie.Id);
            if (updatingAllergie == null)
            {
                throw new NotFoundException();
            }
            
            updatingAllergie.Update(allergie);
            
            _context.SaveChanges();
            return updatingAllergie;
        }

        public void Delete(Guid allergieId)
        {
            var allergie = GetById(allergieId);
            _context.Allergies.Remove(allergie);
            _context.SaveChanges();
        }
    }
}
