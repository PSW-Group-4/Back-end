using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Model;

namespace HospitalLibrary.BuildingManagmentMap.Service.Interfaces
{
    public interface IFloorMapService : ICrudService<FloorMap>
    {
        public IEnumerable<FloorMap> GetFloorMapsByBuildingId(Guid id);
    }
}
