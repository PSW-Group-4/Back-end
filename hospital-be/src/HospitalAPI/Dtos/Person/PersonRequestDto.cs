using System;
using HospitalAPI.Dtos.Address;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Person
{
    public class PersonRequestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public  AddressRequestDto Address { get; set; }
        public Jmbg Jmbg { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}