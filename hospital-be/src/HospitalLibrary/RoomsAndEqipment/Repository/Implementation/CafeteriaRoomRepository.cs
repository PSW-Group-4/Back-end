using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Implementation
{
    public class CafeteriaRoomRepository : ICafeteriaRoomRepository
    {
        private readonly HospitalDbContext _context;

        public CafeteriaRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public CafeteriaRoom Create(CafeteriaRoom entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CafeteriaRoom> GetAll()
        {
            throw new NotImplementedException();
        }

        public CafeteriaRoom GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CafeteriaRoom Update(CafeteriaRoom entity)
        {
            throw new NotImplementedException();
        }
    }
}