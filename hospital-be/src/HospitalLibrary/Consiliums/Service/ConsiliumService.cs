using HospitalLibrary.Appointments.Service;
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
        private readonly IDoctorAppointmentService _doctorAppointmentService;
        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorService doctorService, IDoctorAppointmentService doctorAppointmentService)
        {
            _consiliumRepository = consiliumRepository;
            _doctorService = doctorService;
            _doctorAppointmentService = doctorAppointmentService;
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
            for (DateTime termin = consiliumRequest.DateStart; termin.AddMinutes(30 * consiliumRequest.Duration) <= consiliumRequest.DateEnd; termin.AddMinutes(30))
            {
                foreach(Guid doctorId in consiliumRequest.DoctorsId)
                {
                    /*for (DateTime allTermins = termin; allTermins <= termin.AddMinutes(30 * consiliumRequest.Duration); allTermins.AddMinutes(30))
                    {
                        if (!(_doctorAppointmentService.IsDoctorAvailable(doctorId, allTermins)))
                        {
                            doctorsFound = false;
                            break;
                        }
                    }*/
                    if (!(_doctorAppointmentService.IsDoctorAvailable(doctorId, termin)))
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
