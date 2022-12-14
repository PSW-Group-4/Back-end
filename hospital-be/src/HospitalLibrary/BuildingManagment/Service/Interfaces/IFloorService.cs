using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagment.Service.Interfaces
{
    public interface IFloorService : IServiceBase<Floor>
    {
        public IEnumerable<Room> GetRoomsByFloorId(Guid id);
        public Floor GetFloorByRoomId(Guid id);
    }
}