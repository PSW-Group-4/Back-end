using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

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
    }
}
