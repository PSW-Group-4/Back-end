using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Repository;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Service
{
    public class ConsiliumService : IConsiliumService
    {
        private readonly IConsiliumRepository _consiliumRepository;
        private readonly IDoctorService _doctorService;
        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorService doctorService)
        {
            _consiliumRepository = consiliumRepository;
            _doctorService = doctorService;
        }
        // PETAR TODO
        public IEnumerable<Consilium> GetDoctorsConsiliums(Guid DoctorId)
        {
            throw new NotImplementedException();
        }

        // DJOLE TODO
        public Consilium Create(ConsiliumRequest consiliumRequest)
        {
            Consilium consiliumCreated = TryToCreateConsilium(consiliumRequest);
            if (consiliumCreated != null)
            {
                return consiliumCreated;
            }
            return null;

        }

        private Consilium TryToCreateConsilium(ConsiliumRequest consiliumRequest)
        {
            if (consiliumRequest.isDoctor)
            {
                return ConsiliumWithDoctors(consiliumRequest);
            }
            else
            {
                return ConsiliumWithSpecialities(consiliumRequest);
            }
        }

        private Consilium ConsiliumWithDoctors(ConsiliumRequest consiliumRequest)
        {
            bool doctorsFound = false;
            DateTime terminFound = consiliumRequest.DateStart;
            for (DateTime termin = consiliumRequest.DateStart; termin <= consiliumRequest.DateEnd.AddMinutes(consiliumRequest.Duration); termin.AddMinutes(30))
            {
                foreach(Guid doctorId in consiliumRequest.DoctorsId)
                {
                    if (!DoctorAvailable(termin, consiliumRequest))
                    {
                        doctorsFound = false;
                        break;
                    }
                    doctorsFound = true;
                }
                terminFound = termin;
            }
            if (doctorsFound)
            {
                return CreateConsilium(terminFound, consiliumRequest);
            }
            return null;
        }

        private Consilium CreateConsilium(DateTime terminFound, ConsiliumRequest consiliumRequest)
        {
            Consilium consilium = new Consilium()
            {
                Reason = consiliumRequest.Reason,
                //DoctorsId = consiliumRequest.DoctorsId,
                // ostale stvari koje ja ne znam sta su hahahah

            };
            return _consiliumRepository.Create(consilium);
        }

        private bool DoctorAvailable(DateTime termin, ConsiliumRequest consiliumRequest)
        {
            // da li je u radnom vremenu termin
            if (IsInDoctorWorkingTime(DateTime.Now))
            {
                return false;
            }
            // da li je doktor na godisnjem
            if (IsDoctorOnVacation(DateTime.Now))
            {
                return false;
            }
            // da li doktor tad ima pregled
            if (IsDoctorOnMedicalAppointment(DateTime.Now))
            {
                return false;
            }
            return true;
        }
        private bool IsInDoctorWorkingTime(object p)
        {
            throw new NotImplementedException();
        }
        private bool IsDoctorOnVacation(DateTime now)
        {
            throw new NotImplementedException();
        }
        private bool IsDoctorOnMedicalAppointment(object p)
        {
            throw new NotImplementedException();
        }

        private Consilium ConsiliumWithSpecialities(ConsiliumRequest consiliumRequest)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consilium> GetAll()
        {
            return _consiliumRepository.GetAll();
        }

        public Consilium GetById(Guid id)
        {
            return _consiliumRepository.GetById(id);
        }

        
    }
}
