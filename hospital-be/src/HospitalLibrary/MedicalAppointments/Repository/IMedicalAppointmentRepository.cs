using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Appointments.Repository
{
    public interface IMedicalAppointmentRepository : IRepositoryBase<MedicalAppointment> 
    {
        public IEnumerable<MedicalAppointment> GetDoneByPatient(Guid patientId);

        public IEnumerable<MedicalAppointment> GetCacneledByPatient(Guid patientId);

        public IEnumerable<MedicalAppointment> GetFutureByPatient(Guid patientId);
    }
}
