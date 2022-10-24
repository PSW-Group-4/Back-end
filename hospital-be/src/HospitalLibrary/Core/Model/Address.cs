using System;

namespace HospitalLibrary.Core.Model
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
