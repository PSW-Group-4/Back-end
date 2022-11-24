using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Repository
{
    public class BedRepository : IBedRepository
    {
        private readonly HospitalDbContext _context;
        public BedRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Bed Create(Bed entity)
        {
            entity.IsFree = true;
            _context.Beds.Add(entity);            
            _context.SaveChanges();
            return entity;
        }
        public void Delete(Guid bedId)
        {
            var bed = GetById(bedId);
            _context.Beds.Remove(bed);
            _context.SaveChanges();
        }

        public IEnumerable<Bed> GetAll()
        {
            return _context.Beds.ToList();
        }

        public Bed GetById(Guid id)
        {
            var result = _context.Beds.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Bed Update(Bed bed)
        {
            var updatingBed = _context.Beds.SingleOrDefault(p => p.Id == bed.Id);
            if (updatingBed == null)
            {
                throw new NotFoundException();
            }

            updatingBed.Update(bed);

            _context.SaveChanges();
            return updatingBed;
        }

        public Bed FreeBed(Bed bed)
        {
            var updatingBed = _context.Beds.SingleOrDefault(p => p.Id == bed.Id);
            if (updatingBed == null)
            {
                throw new NotFoundException();
            }

            updatingBed.FreeBed(bed);

            _context.SaveChanges();
            return updatingBed;
        }
        public Bed CaptureBed(Bed bed)
        {
            var updatingBed = _context.Beds.SingleOrDefault(p => p.Id == bed.Id);
            if (updatingBed == null)
            {
                throw new NotFoundException();
            }

            updatingBed.CaptureBed(bed);

            _context.SaveChanges();
            return updatingBed;
        }
    }
}
