using System;
using System.Collections.Generic;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Repository
{
    public interface IMedicalAppointmentSchedulingSessionRepository : IEventRepository<
        MedicalAppointmentSchedulingSessionEvent, MedicalAppointmentSchedulingSession>
    {
        public IDictionary<Doctor, int> GetNumberOfChoosesPerDoctor();
    }
}