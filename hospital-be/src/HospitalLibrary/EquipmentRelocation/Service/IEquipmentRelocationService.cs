using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.EquipmentRelocation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EquipmentRelocation.Service
{
    public interface IEquipmentRelocationService
    {
        public List<DateTime> RecommendRelocationStart(EquipmentRelocation.DTO.EquipmentRelocationDTO dto);


        public List<DateTime> GetAvailableDates(List<RoomSchedule> appointments, DTO.EquipmentRelocationDTO dto);
        IEnumerable<EquipmentRelocationDTO> GetAll();
    }
}
