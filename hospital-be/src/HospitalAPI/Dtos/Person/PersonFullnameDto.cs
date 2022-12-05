using System;

namespace HospitalAPI.Dtos.Person
{
    public class PersonFullnameDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}