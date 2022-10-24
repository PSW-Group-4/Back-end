using System;
using HospitalAPI.Controllers.Dtos.Address;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Controllers.Dtos.Person
{
    public class PersonRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public  AddressRequestDto Address { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}