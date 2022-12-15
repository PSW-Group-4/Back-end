using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.Renovation.Repository.Interfaces;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.MoveEquipment.Model;

namespace HospitalLibrary.Renovation.Service.Implementation
{
    public class RenovationAppointmentService : IRenovationAppointmentService
    {
        private readonly IRenovationAppointmentRepository _renovationAppointmentRepository;
        private readonly IRoomService _roomService;

        public RenovationAppointmentService(IRenovationAppointmentRepository equipmentToMoveRepository, IRoomService roomService)
        {
            _renovationAppointmentRepository = equipmentToMoveRepository;
            _roomService = roomService;
        }

        public RenovationAppointment Create(RenovationAppointment entity)
        {
            return _renovationAppointmentRepository.Create(entity);
        }

        public void Delete(Guid id)
        {
            RenovationAppointment renovation= GetById(id);
            
            if (renovation.DateRange.StartTime.AddDays(-1) < DateTime.Now)
            {
                return;
            }
            //if it use two rooms, delete appointment in both of them
            //not the best logic, because of project construction, but works for now
            if(renovation.Type == RenovationAppointment.TypeOfRenovation.Merge) {
                foreach (RenovationAppointment appointment in GetAll())
                {
                    if (appointment.Id != id && appointment.DateRange.StartTime == renovation.DateRange.StartTime)
                    {
                        _renovationAppointmentRepository.Delete(appointment.Id);
                        break;
                    }
                }
            }
            
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
            plans.Add(new RoomRenovationPlan(new Guid(data.Room1.Id)));
            if(Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type) == RenovationAppointment.TypeOfRenovation.Merge) {
                plans.Add(new RoomRenovationPlan(new Guid(data.Room2.Id)));
            }
            else {
                plans.Add(new RoomRenovationPlan(data.Room2.Name, data.Room2.Description, data.Room2.Number));
            }
            plans.Add(new RoomRenovationPlan(data.Room3.Name, data.Room3.Description, data.Room3.Number));
            RenovationAppointment appointment = new RenovationAppointment(Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type), plans, new DateRange(data.StartTime, data.EndTime), new Guid(data.Room1.Id));
            this.Create(appointment);
            if(Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type) == RenovationAppointment.TypeOfRenovation.Merge) {
                RenovationAppointment appointment2 = new RenovationAppointment(Enum.Parse<RenovationAppointment.TypeOfRenovation>(data.Type), plans, new DateRange(data.StartTime, data.EndTime), new Guid(data.Room2.Id));
                this.Create(appointment2);
            }
        }

        public void CheckForFinishedRenovations() {
            foreach( RenovationAppointment appointment in this.GetAll() ) {
                if(appointment.ShouldBeFinished()) {
                    FinishRenovation(appointment);
                }
            }
        }

        // Do not refactor
        public void FinishRenovation(RenovationAppointment appointment) {
            if(appointment.IsPrimaryRenovationAppointment()) {
                appointment.Finish();
                _roomService.FinishRenovationPlans(appointment.GetAllPlans(), appointment.Type);
            }
            else {
                appointment.Finish();
            }
            this.Update(appointment);
            
        }
    }
}