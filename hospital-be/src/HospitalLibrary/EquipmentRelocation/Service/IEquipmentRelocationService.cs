using HospitalLibrary.Appointments.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.EquipmentRelocation.Service
{
    public interface IEquipmentRelocationService
    {
        public List<DateTime> RecommendRelocationStart(EquipmentRelocation.DTO.EquipmentRelocation dto);

        public List<DateTime> GetAvailableDates(List<RoomSchedule> appointments, DTO.EquipmentRelocation dto);
    }
}
