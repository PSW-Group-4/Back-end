using HospitalLibrary.Appointments.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Appointments.Service
{
    public interface IMedicalAppointmentService
    {
        IEnumerable<MedicalAppointment> GetAll();
        MedicalAppointment GetById(Guid id);
        MedicalAppointment Create(MedicalAppointment medicalAppointment);
        MedicalAppointment Update(MedicalAppointment medicalAppointment);
        void Delete(Guid appointmentId);
    }
}
