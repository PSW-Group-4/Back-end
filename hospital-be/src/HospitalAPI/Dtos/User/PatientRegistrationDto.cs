using HospitalAPI.Dtos.Address;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Person;
using HospitalLibrary.Allergies;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.User
{
    public class PatientRegistrationDto
    {
        //User
        public UserLoginDto UserLoginDto { get; set; }

        //Address
        public AddressRequestDto AddressRequestDto { get; set; }

        //Person info
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        //Patient info
        public BloodType BloodType { get; set; }
        public List<Guid> AllergieIds { get; set; }
        public Guid ChoosenDoctorId { get; set; }
    }
}
