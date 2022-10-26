using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class CafeteriaRoomService : ICafeteriaRoomService
    {
        private readonly ICafeteriaRoomRepository _cafeteriaRoomRepository;

        public CafeteriaRoomService(ICafeteriaRoomRepository cafeteriaRoomRepository)
        {
            _cafeteriaRoomRepository = cafeteriaRoomRepository;
        }

        public CafeteriaRoom Create(CafeteriaRoom entity)
        {
            return _cafeteriaRoomRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _cafeteriaRoomRepository.Delete(id);
        }

        public IEnumerable<CafeteriaRoom> GetAll()
        {
            return _cafeteriaRoomRepository.GetAll();
        }

        public CafeteriaRoom GetById(Guid id)
        {
            return _cafeteriaRoomRepository.GetById(id);
        }

        public CafeteriaRoom Update(CafeteriaRoom entity)
        {
            return _cafeteriaRoomRepository.Update(entity);
        }
    }
}