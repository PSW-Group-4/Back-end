using HospitalLibrary.Appointments.Service;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;

namespace HospitalLibrary.EquipmentRelocation.Service
{
    public class EquipmentRelocationService : IEquipmentRelocationService
    {
        private readonly IAppointmentService _appointemntService;


        public EquipmentRelocationService( IAppointmentService appointemntService)
        {
            _appointemntService = appointemntService;
        }

        public List<DateTime> RecommendRelocationStart(EquipmentRelocation.DTO.EquipmentRelocation dto)
        {
            List<Appointment> appointments = (List<Appointment>)_appointemntService.GetAll();
            appointments.Add(new Appointment { DateTime = new DateTime(9999, 12, 12, 3, 30, 0), RoomId = dto.targetId });

            dto.relocationStart = CheckDate(dto.relocationStart);
            dto.duration = CheckDuration(dto.duration);

            return GetAvailableDates(appointments, dto);
        }

        public List<DateTime> GetAvailableDates(List<Appointment> appointments, DTO.EquipmentRelocation dto)
        {
            List<DateTime> result = new List<DateTime>();
            do
            {
                foreach (Appointment appointment in appointments)
                {
                    if (appointment.DateTime.AddMinutes(30) > dto.relocationStart && (appointment.RoomId.Equals(dto.targetId) || appointment.RoomId.Equals(dto.sourceId)))
                    {
                        if ((dto.relocationStart < appointment.DateTime.AddMinutes(30)) && (appointment.DateTime < dto.relocationStart.AddMinutes(dto.duration)))
                        {
                            break;
                        }
                        else { if (!result.Contains(dto.relocationStart)) { result.Add(dto.relocationStart); } }
                    }
                }
                dto.relocationStart = dto.relocationStart.AddMinutes(15);
            } while (result.Count < 10); ;
            return result;
        }

        private DateTime CheckDate(DateTime date) 
        {
            if (date.Minute % 15 != 0)
            {
                date = date.AddMinutes(15 - date.Minute % 15);
            }
            
            return date;
        }

        private int CheckDuration(int duration)
        {
            if (duration % 15 != 0)
            {
                duration += 15 - duration % 15;
            }
            return duration;
        }
    }
}
