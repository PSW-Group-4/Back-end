using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.Renovation.Repository.Interfaces;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.Service.Implementation
{
    public class RenovationAppointmentService : IRenovationAppointmentService
    {
         private readonly IRenovationAppointmentRepository _renovationAppointmentRepository;

        public RenovationAppointmentService(IRenovationAppointmentRepository equipmentToMoveRepository)
        {
            _renovationAppointmentRepository = equipmentToMoveRepository;
        }

        public RenovationAppointment Create(RenovationAppointment entity)
        {
            return _renovationAppointmentRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            _renovationAppointmentRepository.Delete(id);
        }

        public IEnumerable<RenovationAppointment> GetAll()
        {
            return _renovationAppointmentRepository.GetAll();
        }

        public RenovationAppointment GetById(Guid id)
        {
            return _renovationAppointmentRepository.GetById(id);
        }

        public RenovationAppointment Update(RenovationAppointment entity)
        {
            return _renovationAppointmentRepository.Update(entity);
        }

        public void CreateRenovation(RenovationDataDto data) {
            List<RoomRenovationPlan> plans = new List<RoomRenovationPlan>();
            plans.Add(data.Room1);
            plans.Add(data.Room2);
            plans.Add(data.Room3);
            RenovationAppointment appointment = new RenovationAppointment(Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type), plans, data.DateRange);
            this.Create(appointment);
        }
    }
}