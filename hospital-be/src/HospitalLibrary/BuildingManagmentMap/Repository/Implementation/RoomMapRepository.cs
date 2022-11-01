using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.BuildingManagmentMap.Repository.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Settings;

namespace HospitalLibrary.BuildingManagmentMap.Repository.Implementation
{
    public class RoomMapRepository : IRoomMapRepository
    {

        private readonly HospitalDbContext _context;

        public RoomMapRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public RoomMap Create(RoomMap entity)
        {
            _context.RoomMaps.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Guid id)
        {
            var buildingMap = GetById(id);
            _context.RoomMaps.Remove(buildingMap);
            _context.SaveChanges();
        }

        public IEnumerable<RoomMap> GetAll()
        {
            return _context.RoomMaps.ToList();
        }

        public RoomMap GetById(Guid id)
        {
            var result = _context.RoomMaps.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public RoomMap Update(RoomMap entity)
        {
            var updatingRoomMaps = _context.RoomMaps.SingleOrDefault(p => p.Id == entity.Id);
            if (updatingRoomMaps == null)
            {
                throw new NotFoundException();
            }

            updatingRoomMaps.Update(entity);

            _context.SaveChanges();
            return updatingRoomMaps;
        }
    }
}
