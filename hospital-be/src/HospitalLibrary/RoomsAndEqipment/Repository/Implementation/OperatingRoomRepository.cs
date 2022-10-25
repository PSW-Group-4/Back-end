using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.RoomsAndEqipment.Repository
{
    public class OperatingRoomRepository : IOperatingRoomRepository
    {
        private readonly HospitalDbContext _context;

        public OperatingRoomRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public OperatingRoom Create(OperatingRoom entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OperatingRoom> GetAll()
        {
            throw new NotImplementedException();
        }

        public OperatingRoom GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public OperatingRoom Update(OperatingRoom entity)
        {
            throw new NotImplementedException();
        }
    }
}