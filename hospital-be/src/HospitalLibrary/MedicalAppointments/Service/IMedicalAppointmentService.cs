using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
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

        void Cancel(Guid appointmentId, Guid patientId);
        bool IsPatientFree(Guid patientId, DateRange dateRange);
        IEnumerable<MedicalAppointment> GetAllPatientAppointments(Guid patientId);

        public IEnumerable<MedicalAppointment> GetDoneByPatient(Guid patientId);

        public IEnumerable<MedicalAppointment> GetCanceledByPatient(Guid patientId);

        public IEnumerable<MedicalAppointment> GetFutureByPatient(Guid patientId);
    }
}
