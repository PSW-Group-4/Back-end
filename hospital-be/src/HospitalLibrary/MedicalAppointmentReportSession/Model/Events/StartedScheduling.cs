using HospitalLibrary.Doctors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class StartedScheduling : MedicalAppointmentReportSessionEvent
    {
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; }

        //EF needs this constructor
        public StartedScheduling(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }

        public StartedScheduling(Guid aggregateId, DateTime occurrenceTime, Doctor doctor) : base(aggregateId,
            occurrenceTime)
        {
            DoctorId = doctor.Id;
            Doctor = doctor;
        }
    }
}
