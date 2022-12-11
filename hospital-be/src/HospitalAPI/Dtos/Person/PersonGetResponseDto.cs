using System;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Person
{
    public class PersonGetResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Guid AddressId { get; set; }
        public  HospitalLibrary.Core.Model.Address Address { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}