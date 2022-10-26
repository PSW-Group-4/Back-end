using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class DoctorRoomService : IDoctorRoomService
    {
        private readonly IDoctorRoomRepository _doctorRoomRepository;

        public DoctorRoomService(IDoctorRoomRepository doctorRoomRepository)
        {
            _doctorRoomRepository = doctorRoomRepository;
        }
        public IEnumerable<DoctorRoom> GetAll()
        {
            return _doctorRoomRepository.GetAll();
        }

        public DoctorRoom GetById(Guid id)
        {
            return _doctorRoomRepository.GetById(id);
        }

        public DoctorRoom Create(DoctorRoom room)
        {
            return _doctorRoomRepository.Create(room);
        }

        public DoctorRoom Update(DoctorRoom room)
        {
            return _doctorRoomRepository.Update(room);
        }

        public void Delete(Guid roomId)
        {
            _doctorRoomRepository.Delete(roomId);
        }
    }
}
