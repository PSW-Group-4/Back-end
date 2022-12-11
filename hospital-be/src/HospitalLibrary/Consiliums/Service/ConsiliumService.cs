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
            
            List<Guid> doctorIds = new List<Guid>();
            for (DateTime termin = consiliumRequest.DateStart; termin <= consiliumRequest.DateEnd.AddMinutes(-30 * consiliumRequest.Duration); termin = termin.AddMinutes(30))
            {
                bool badTermin = false;
                foreach (Guid doctorId in consiliumRequest.DoctorsId)   
                {
                    for (DateTime longerTermin = termin; longerTermin < termin.AddMinutes(30 * consiliumRequest.Duration - 1); longerTermin = longerTermin.AddMinutes(30))
                    {
                        if (!(_doctorAppointmentService.IsDoctorAvailable(doctorId, termin)))
                        {
                            badTermin = true;
                            break;
                        }

                    }
                    if (badTermin)
                    {
                        break;
                    }
                    else
                    {
                        doctorIds.Add(doctorId);
                        if (doctorIds.Count == consiliumRequest.DoctorsId.Count)
                        {
                            return CreateConsilium(termin, consiliumRequest);
                        }
                    }
                }
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
