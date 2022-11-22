using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Interfaces
{
    public interface IPatientRoomService
    {
        IEnumerable<PatientRoom> GetAll();
        PatientRoom GetById(Guid id);
        PatientRoom Create(PatientRoom room);
        PatientRoom Update(PatientRoom room);
        void Delete(Guid roomId);

        public List<PatientRoom> GetRoomsWithFreeBeds();
        public PatientRoom CaptureBed(PatientRoom patientRoom);
        public PatientRoom FreeBed(PatientRoom patientRoom);
    }
}
