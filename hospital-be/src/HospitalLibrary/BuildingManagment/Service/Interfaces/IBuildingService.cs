using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Core.Service.Interfaces;

namespace HospitalLibrary.BuildingManagment.Service.Interfaces
{
    public interface IBuildingService : IServiceBase<Building>
    {
        public IEnumerable<Floor> GetFloorsByBuildingId(Guid id);
    }
}