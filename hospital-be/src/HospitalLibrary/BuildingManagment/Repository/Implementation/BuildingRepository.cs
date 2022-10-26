using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagment.Repository.Implementation
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly HospitalDbContext _context;

        public BuildingRepository(HospitalDbContext context)
        {
            _context = context;
        }
        public Building Create(Building entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Building> GetAll()
        {
            throw new NotImplementedException();
        }

        public Building GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Building Update(Building entity)
        {
            throw new NotImplementedException();
        }
    }
}