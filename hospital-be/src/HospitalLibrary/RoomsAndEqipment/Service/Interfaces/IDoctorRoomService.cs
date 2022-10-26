using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Service.Interfaces
{
    public interface IDoctorRoomService
    {
        IEnumerable<DoctorRoom> GetAll();
        DoctorRoom GetById(Guid id);
        DoctorRoom Create(DoctorRoom room);
        DoctorRoom Update(DoctorRoom room);
        void Delete(Guid roomId);
    }
}
