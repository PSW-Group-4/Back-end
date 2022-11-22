using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Implementation
{
    public class PatientRoomService : IPatientRoomService
    {
        private readonly IPatientRoomRepository _patientRoomRepository;
        public PatientRoomService(IPatientRoomRepository patientRoomRepository)
        {
            _patientRoomRepository = patientRoomRepository;
        }
        public IEnumerable<PatientRoom> GetAll()
        {
            return _patientRoomRepository.GetAll();
        }

        public PatientRoom GetById(Guid id)
        {
            return _patientRoomRepository.GetById(id);
        }

        public PatientRoom Create(PatientRoom room)
        {
            return _patientRoomRepository.Create(room);
        }

        public PatientRoom Update(PatientRoom room)
        {
            return _patientRoomRepository.Update(room);
        }

        public void Delete(Guid roomId)
        {
            _patientRoomRepository.Delete(roomId);
        }
        public List<PatientRoom> GetRoomsWithFreeBeds()
        {
            if (_patientRoomRepository.GetRoomsWithFreeBeds() != null)
                return _patientRoomRepository.GetRoomsWithFreeBeds();
            else
                return null;
        }

        public PatientRoom CaptureBed(PatientRoom patientRoom)
        {
            return _patientRoomRepository.CaptureBed(patientRoom);
        }
        public PatientRoom FreeBed(PatientRoom patientRoom)
        {
            return _patientRoomRepository.FreeBed(patientRoom);
        }
    }
}
