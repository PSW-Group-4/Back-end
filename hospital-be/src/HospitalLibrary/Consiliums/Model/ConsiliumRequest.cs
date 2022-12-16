using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Model
{
    public class ConsiliumRequest
    {
        public String Reason { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public int Duration { get; private set; }
        public bool isDoctor { get; private set; }
        public List<Guid> DoctorsId { get; private set; }
        public List<String> Specialities { get; private set; }

        public ConsiliumRequest(string reason, DateTime dateStart, DateTime dateEnd, int duration, bool isDoctor, List<Guid> doctorsId, List<string> specialities)
        {
            Reason = reason;
            DateStart = dateStart;
            DateEnd = dateEnd;
            Duration = duration;
            this.isDoctor = isDoctor;
            DoctorsId = doctorsId;
            Specialities = specialities;

            if (!IsValid())
            {
                throw new ValueObjectValidationFailedException("ConsiliumRequest doesn't exist !");
            }
        }


        private bool IsValid()
        {
            if (Reason == null)
            {
                return false;
            }
            if (!IsGoodDate())
            {
                return false;
            }
            if (!IsGoodDuration())
            {
                return false;
            }
            if (!IsDoctorOrSpecialityChosen())
            {
                return false;
            }
            return true;
        }

        private bool IsGoodDate()
        {
            return DateTime.Compare(DateStart, DateEnd) < 0;
        }
        private bool IsGoodDuration()
        {
            return Duration > 0;
        }
        private bool IsDoctorOrSpecialityChosen()
        {
            if (isDoctor)
            {
                return IsDoctorChosen();
            }
            else
            {
                return IsSpecialityChosen();
            }
        }
        private bool IsDoctorChosen()
        {
            if(DoctorsId.Count > 0)
            {
                return true;
            }
            return false;
        }
        private bool IsSpecialityChosen()
        {
            if (Specialities.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}