using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;

namespace HospitalLibrary.Core.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}