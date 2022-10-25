using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagment.Repository.Intefaces;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagment.Repository.Implementation
{
    public class FloorRepository : IFloorRepository
    {
        private readonly HospitalDbContext _context;

        public FloorRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public Floor Create(Floor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Floor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Floor GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Floor Update(Floor entity)
        {
            throw new NotImplementedException();
        }
    }
}