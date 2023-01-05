using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Core.Model
{
    public enum Gender
    {
        Male,
        Female
    }
    public  class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private  set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; private set; }
        public Gender Gender { get; private set; }
        public Guid AddressId { get; private set; }
        public virtual Address Address { get; private set; }

        [Column(TypeName = "jsonb")]
        public virtual Jmbg Jmbg { get; private set; }
        public Email Email { get; private set; }
        public string PhoneNumber { get; private set; }

    
        public Person(){}

        public Person(Guid id, string name, string surname, DateTime birthdate, Gender gender, Address address, Jmbg jmbg, Email email, string phoneNumber)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Birthdate = birthdate;
            Gender = gender;
            AddressId = address.Id;
            Address = address;
            Jmbg = jmbg;
            Email = email;
            PhoneNumber = phoneNumber;
            Validate();
        }

        private void Validate()
        {
            if (Id.Equals(Guid.Empty) )
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Name))
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(Surname))
                throw new EntityObjectValidationFailedException();
            if (DateTime.Now<Birthdate)
                throw new EntityObjectValidationFailedException();
            if (Address==null)
                throw new EntityObjectValidationFailedException();
            if (AddressId.Equals(Guid.Empty))
                throw new EntityObjectValidationFailedException();
            if (Jmbg==null)
                throw new EntityObjectValidationFailedException();
            if (Email==null)
                throw new EntityObjectValidationFailedException();
            if (string.IsNullOrEmpty(PhoneNumber))
                throw new EntityObjectValidationFailedException();

        }
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

        public int GetAge()
        {
            return DateTime.Now.Year - Birthdate.Year;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
