using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<Room> GetAll()
        {
            return _roomRepository.GetAll();
        }

        public Room GetById(Guid id)
        {
            return _roomRepository.GetById(id);
        }

        public Room Create(Room room)
        {
            return _roomRepository.Create(room);
        }

        public Room Update(Room room)
        {
            return _roomRepository.Update(room);
        }

        public void Delete(Guid roomId)
        {
            _roomRepository.Delete(roomId);
        }

        public List<Room> GetConsiliumRoom()
        {
            List<Room> roomList = new List<Room>();
            foreach (Room room in GetAll())
            {
                if (room.Description.Equals("ConsiliumRoom"))
                {
                    roomList.Add(room);
                }
            }
            return roomList;
        }
    }
}
