using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Doctors.Model
{
    public class Doctor : Person
    {
        public string LicenceNum { get; private set; }
        public string Speciality { get; private set; }
        public string WorkingTimeStart { get; private set; }
        public string WorkingTimeEnd { get; private set; }
        public Guid RoomId { get; private set; }
        public virtual Room Room { get; private set; }
        public virtual List<Consilium> Consiliums { get; private set; }


        public Doctor() : base()
        { }

        public Doctor(Guid id, string name, string surname, DateTime birthdate, Gender gender, Address address, Jmbg jmbg, Email email, string phoneNumber, string licenceNum, string speciality, string workingTimeStart, string workingTimeEnd, Guid roomId, Room room) : base(id, name, surname, birthdate, gender, address, jmbg, email, phoneNumber)
        {
            LicenceNum = licenceNum;
            Speciality = speciality;
            WorkingTimeStart = workingTimeStart;
            WorkingTimeEnd = workingTimeEnd;
            RoomId = roomId;
            Room = room;
            Consiliums = new List<Consilium>();
            if (!IsValid())
            {
                throw new ValueObjectValidationFailedException("Doctor Must have Work Time !");
            }
        }


        public void Update(Doctor doctor)
        {
            base.Update(doctor);
            LicenceNum = doctor.LicenceNum;
            Speciality = doctor.Speciality;
            WorkingTimeStart = doctor.WorkingTimeStart;
            WorkingTimeEnd = doctor.WorkingTimeEnd;
        }

        public bool IsInWorkHours(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }

            DateTime WorkTimeStart = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(this.WorkingTimeStart).Hour, DateTime.Parse(this.WorkingTimeStart).Minute, 0);
            DateTime WorkTimeEnd = new DateTime(date.Year, date.Month, date.Day, DateTime.Parse(this.WorkingTimeEnd).Hour, DateTime.Parse(this.WorkingTimeEnd).Minute, 0);

            if (DateTime.Compare(date, WorkTimeStart) >= 0
                && DateTime.Compare(date, WorkTimeEnd) < 0)
            {
                return true;
            }
            return false;
        }

        public bool IsSpeciality(String speciality)
        {
            if (speciality.Equals(this.Speciality))
                return true;
            return false;
        }

        private bool IsValid()
        {
            if ((String.IsNullOrEmpty(WorkingTimeStart)) || (String.IsNullOrEmpty(WorkingTimeEnd)))
            {
                return false;
            }
            return true;
        }
    }
}
