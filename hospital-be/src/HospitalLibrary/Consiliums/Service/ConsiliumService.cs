using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Microsoft.VisualBasic;
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
        private readonly IRoomService _roomService;
        public ConsiliumService(IConsiliumRepository consiliumRepository, IDoctorService doctorService, IDoctorAppointmentService doctorAppointmentService, IRoomService roomService)
        {
            _consiliumRepository = consiliumRepository;
            _doctorService = doctorService;
            _doctorAppointmentService = doctorAppointmentService;
            _roomService = roomService;
        }
        // PETAR TODO
        public IEnumerable<Consilium> GetDoctorsConsiliums(Guid DoctorId)
        {
            IEnumerable<Consilium> allConsiliums = _consiliumRepository.GetAll();
            List<Consilium> docConsiliums = new List<Consilium>();
            foreach(Consilium consilium in allConsiliums)
            {
                foreach(Doctor doc in consilium.Doctors)
                {
                    if (doc.Id.Equals(DoctorId))
                        docConsiliums.Add(consilium);
                }
            }
            return docConsiliums;
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
            
            
            for (DateTime termin = consiliumRequest.DateStart; termin <= consiliumRequest.DateEnd.AddMinutes(-30 * consiliumRequest.Duration); termin = termin.AddMinutes(30))
            {
                List<Guid> doctorIds = new List<Guid>();
                foreach (Guid doctorId in consiliumRequest.DoctorsId)   
                {
                    if (!(IsLongerTerminGoodForDoctor(doctorId, termin, consiliumRequest)))
                    {
                        break;
                    }
                    DateRange dr = new DateRange(termin, termin.AddMinutes(30 * consiliumRequest.Duration));
                    Room roomAvailable = FindRoomForConsilium(dr);
                    if (roomAvailable == null){
                        break;
                    }
                    doctorIds.Add(doctorId);
                    if (doctorIds.Count == consiliumRequest.DoctorsId.Count)
                    {
                        return CreateConsilium(termin, roomAvailable.Id, consiliumRequest);
                    }
                    
                }
            }
            return null;
        }

        private bool IsLongerTerminGoodForDoctor(Guid doctorId, DateTime termin, ConsiliumRequest consiliumRequest)
        {
            for (DateTime longerTermin = termin; longerTermin < termin.AddMinutes(30 * consiliumRequest.Duration - 1); longerTermin = longerTermin.AddMinutes(30))
            {
                if (!(_doctorAppointmentService.IsDoctorAvailable(doctorId, longerTermin)))
                {
                    return false;
                }
            }
            return true;
        }

        private Consilium CreateConsilium(DateTime terminFound,Guid RoomId, ConsiliumRequest consiliumRequest)
        {
            DateRange dr = new DateRange(terminFound, terminFound.AddMinutes(30 * consiliumRequest.Duration));
            List<Doctor> doctors = new List<Doctor>();
            foreach(Guid d in consiliumRequest.DoctorsId)
            {
                doctors.Add(_doctorService.GetById(d));
            }


            Consilium consilium =
                new Consilium(Guid.NewGuid(), dr, RoomId, null, consiliumRequest.Reason, doctors);
            // {
            //     Reason = consiliumRequest.Reason,
            //     IsDone = false,
            //     RoomId = RoomId,
            //     DateRange = dr,
            //     Doctors = doctors
            //     
            //     //DoctorsId = consiliumRequest.DoctorsId,
            //     // ostale stvari koje ja ne znam sta su hahahah
            //
            // };
            return _consiliumRepository.Create(consilium);
        }

        private Room FindRoomForConsilium(DateRange dr)
        {
            List<Room> allRooms = _roomService.GetConsiliumRoom();
            List<Consilium> consiliums = GetAll().ToList();
            bool noConsiliums = true;
            bool found = true;

            foreach (Room room in allRooms)
            {
                foreach(Consilium consilium in consiliums)
                {
                    noConsiliums = false;
                    if(consilium.RoomId == room.Id
                      && (consilium.DateRange.OverlapsWith(dr)))
                    {
                        found = false;
                        break;
                    }
                }
                if (noConsiliums || found)
                {
                    return room;
                }
            }
            return null;
        }

        private Consilium ConsiliumWithSpecialities(ConsiliumRequest consiliumRequest)
        {
            List<Doctor> Doctors = GetAllDoctorFromSpecialities(consiliumRequest.Specialities);
            List<Doctor> bestAvailableDoctors = new List<Doctor>();
            int MustSpecialityCount = consiliumRequest.Specialities.Count;
            int bestDoctorCount = 0;
            Room roomAvailable = new Room();
            DateTime bestTermin = new DateTime();
            bool didItEvenFound = false;

            for (DateTime termin = consiliumRequest.DateStart; termin <= consiliumRequest.DateEnd.AddMinutes(-30 * consiliumRequest.Duration); termin = termin.AddMinutes(30))
            {
                List<Doctor> availableDoctors = new List<Doctor>();
                List<String> availableSpecialitites = new List<String>();
                foreach (Doctor doctor in Doctors)
                {
                    if (!(IsLongerTerminGoodForDoctor(doctor.Id, termin, consiliumRequest)))
                    {
                        continue;
                    }
                    DateRange dr = new DateRange(termin, termin.AddMinutes(30 * consiliumRequest.Duration));
                    roomAvailable = FindRoomForConsilium(dr);
                    if (roomAvailable == null)
                    {
                        break;
                    }
                        availableDoctors.Add(doctor);
                        availableSpecialitites.Add(doctor.Speciality);
                    if (MustSpecialityCount == availableSpecialitites.Distinct().Count()
                        && availableDoctors.Count() > bestDoctorCount)
                    {
                        didItEvenFound = true;
                        bestDoctorCount = availableDoctors.Count;
                        bestTermin = termin;
                        bestAvailableDoctors = availableDoctors;
                    }
                }
            }
            if (didItEvenFound)
            {
                return CreateConsiliumWithSpecialitites(bestTermin, roomAvailable.Id, consiliumRequest, bestAvailableDoctors);
            }
            return null;
        }

        private Consilium CreateConsiliumWithSpecialitites(DateTime terminFound,Guid roomId, ConsiliumRequest consiliumRequest, List<Doctor> availableDoctors)
        {
            DateRange dr = new DateRange(terminFound, terminFound.AddMinutes(30 * consiliumRequest.Duration));
            Consilium consilium = 
                new Consilium(Guid.NewGuid(), dr, roomId, null , consiliumRequest.Reason, availableDoctors);
            // {
            // {
            //     Reason = consiliumRequest.Reason,
            //     IsDone = false,
            //     RoomId = roomId,
            //     DateRange = dr,
            //     Doctors = availableDoctors
            //
            //     //DoctorsId = consiliumRequest.DoctorsId,
            //     // ostale stvari koje ja ne znam sta su hahahah
            //
            // };
            return _consiliumRepository.Create(consilium);
        }

        private List<Doctor> GetAllDoctorFromSpecialities(List<string> specialitites)
        {
            List<Doctor> AllDoctors = new List<Doctor>();
            List<Doctor> AllDoctorsTest = new List<Doctor>();
            foreach (string specialitite in specialitites)
            {
                List<Doctor> SpecialityDoctors = _doctorService.GetDoctorsWithSpecialty(specialitite).ToList();
                AllDoctorsTest.AddRange(SpecialityDoctors);
                foreach(Doctor doctor in SpecialityDoctors)
                {
                    AllDoctors.Add(doctor);
                }
            }
            return AllDoctors;
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
