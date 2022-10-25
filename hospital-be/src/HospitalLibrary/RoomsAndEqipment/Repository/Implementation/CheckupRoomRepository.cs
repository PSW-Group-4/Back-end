using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RoomsAndEqipment.Repository
{
    public class CheckupRoomRepository : ICheckupRoomRepository
    {
        private readonly HospitalDbContext _context;

        public CheckupRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public CheckupRoom Create(CheckupRoom entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckupRoom> GetAll()
        {
            throw new NotImplementedException();
        }

        public CheckupRoom GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CheckupRoom Update(CheckupRoom entity)
        {
            throw new NotImplementedException();
        }
    }
}