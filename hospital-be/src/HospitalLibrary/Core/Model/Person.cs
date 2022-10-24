using System;

namespace HospitalLibrary.Core.Model
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public Gender Gender { get; set; }
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
        public string Jmbg { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Update(Person person)
        {
            Name = person.Name;
            Surname = person.Surname;
            Birthdate = person.Birthdate;
            Gender = person.Gender;
            Address.Update(person.Address);
            Jmbg = person.Jmbg;
            Email = person.Email;
            PhoneNumber = person.PhoneNumber;
        }
    }
}
