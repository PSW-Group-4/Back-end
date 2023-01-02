using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.Renovation.Service.Interfaces;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.RenovationSessionAggregate.UseCases
{
    public class EndSession
    {
        private IRenovationSessionAggregateRootRepository _sessionRepository;
        private IRenovationAppointmentService _appointmentService;// TODO
        // private IEventRepository _eventRepository
        
        public EndSession(IRenovationSessionAggregateRootRepository sessionRepository, IRenovationAppointmentService appointmentService) {
            this._sessionRepository = sessionRepository;
            this._appointmentService = appointmentService;
        }

        public void Execute(Guid id) {
            RenovationSessionAggregateRoot root = _sessionRepository.GetById(id);
            this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[0].Id));
            if(root.TypeOfRenovation.Value.Equals(HospitalLibrary.Renovation.Model.RenovationAppointment.TypeOfRenovation.Merge)) {
                this._appointmentService.Create(new RenovationAppointment(root, root.RoomRenovationPlans.ToArray()[1].Id));
            }
            root.SessionEnded(root.Id);
            // save event changes
        }
    }
}