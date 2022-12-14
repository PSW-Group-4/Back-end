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
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.BuildingManagment.Service.Interfaces;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagmentMap.Service.Interfaces;
using HospitalLibrary.BuildingManagmentMap.Model;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IFloorService _floorService;
        private readonly IRoomMapService _roomMapService;

        public RoomService(IRoomRepository roomRepository, IFloorService floorService, IRoomMapService roomMapService)
        {
            _roomRepository = roomRepository;
            _floorService = floorService;
            _roomMapService = roomMapService;
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

        public void FinishRenovationPlans(IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation) {
            // create and fill new rooms with equipment
            CreateNewRooms(plans, typeOfRenovation);
            RemoveOldRooms(plans);
        }

        // Creates new rooms from plans and moves equipment from all old rooms to new one
        public void CreateNewRooms(IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation) {
            // Used for calculating room location for splitting
            int roomNumber = 1;
            foreach(RoomRenovationPlan plan in plans) {
                if(plan.Type == RoomRenovationPlan.TypeOfPlan.New) {
                    Room newRoom = new Room(plan);
                    this.MoveEquipmentToRoom(newRoom, plans);
                    this.Create(newRoom);
                    this.SetFloorForNewRoom(newRoom, plans);
                    this.SetMapLocationForNewRoom(newRoom, plans, typeOfRenovation, roomNumber);
                    roomNumber++;
                }  
            }
        }
        // Moves equipment from old rooms to new one
        public void MoveEquipmentToRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans) {
            foreach(RoomRenovationPlan plan in plans) {
                if(plan.Type == RoomRenovationPlan.TypeOfPlan.Old) {
                    Room oldRoom = this.GetById(plan.Id);
                    newRoom.AddEquipment(oldRoom.RoomsEquipment);
                    oldRoom.RemoveAllEquipment();
                }
            }
        }
        // Puts new room to a floor
        public void SetFloorForNewRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans) {
            foreach(RoomRenovationPlan plan in plans) {
                if(plan.Type == RoomRenovationPlan.TypeOfPlan.Old) {
                    Floor floor = _floorService.GetFloorByRoomId(plan.Id);
                    floor.RoomList.Add(newRoom);
                    break;
                }
            }
        }

        // Performs calculations and puts new room map entry for new room
        public void SetMapLocationForNewRoom(Room newRoom, IEnumerable<RoomRenovationPlan> plans, RenovationAppointment.TypeOfRenovation typeOfRenovation, int roomNumber) {
            _roomMapService.Create(new RoomMap(newRoom, _roomMapService.CalculateNewRoomLocation(plans, typeOfRenovation, roomNumber)));
        }

        public void RemoveOldRooms(IEnumerable<RoomRenovationPlan> plans) {
            foreach(RoomRenovationPlan plan in plans) {
                if(plan.Type == RoomRenovationPlan.TypeOfPlan.Old) {
                    _roomMapService.Delete(_roomMapService.GetRoomMapFromRoomId(plan.Id).Id);
                    this.Delete(plan.Id);
                }  
            }
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
