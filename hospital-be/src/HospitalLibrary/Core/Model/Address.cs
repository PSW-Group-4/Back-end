using System;

namespace HospitalLibrary.Core.Model
{
    public class Address
    {
        public Address(){}
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }

        public Address(Guid id, string city, string country, string street, string streetNumber)
        {
            Id = id;
            City = city;
            Country = country;
            Street = street;
            StreetNumber = streetNumber;
        }

        public void Update(Address address)
        {
            City = address.City;
            Country = address.Country;
            Street = address.Street;
            StreetNumber = address.StreetNumber;
        }
    }
}
