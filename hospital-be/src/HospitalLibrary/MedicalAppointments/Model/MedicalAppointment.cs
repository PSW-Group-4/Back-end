using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Core.Model;
using System;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.Appointments.Model
{
    public class MedicalAppointment : Appointment
    {
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; }

        public bool IsCanceled { get; private set; }
        
        public MedicalAppointment(Guid id, DateRange dateRange, Guid? roomId, Room room,
            Guid doctorId, Doctor doctor, Guid patientId, Patient patient, bool isCanceled)
            : base(id, dateRange, roomId, room)
        {
            DoctorId = doctorId;
            Doctor = doctor;
            PatientId = patientId;
            Patient = patient;
            IsCanceled = isCanceled;
            Validate();
        }

        public void Validate()
        {
            if (DoctorId.Equals(Guid.Empty))
            {
                throw new ValueObjectValidationFailedException();
            }
            if (PatientId.Equals(Guid.Empty))
            {
                throw new ValueObjectValidationFailedException();
            }
        }
        
        public void CancelAppointment()
        {
            IsCanceled = true;
        }

        public void SwitchRoomAndDoctor(Guid doctorId, Guid roomId)
        {
            this.DoctorId = doctorId;
            this.RoomId = roomId;
        }
        
        public MedicalAppointment() : base(){}

    }
}
