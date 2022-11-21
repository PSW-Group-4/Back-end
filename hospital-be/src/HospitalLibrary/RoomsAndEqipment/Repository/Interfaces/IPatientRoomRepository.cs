using HospitalLibrary.Core.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Interfaces
{
    public interface IPatientRoomRepository : IRepositoryBase<PatientRoom>
    {
        public List<Bed> GetBedsFromPatientRoom(PatientRoom patientRoom);
        public List<PatientRoom> GetRoomsWithFreeBeds();

    }
}
