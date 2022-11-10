using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Users.Model
{
    public enum UserRole
    {
        PATIENT,
        DOCTOR,
        MANAGER,
        CLERK
    }
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAccountActive { get; set; }
        public bool Blocked { get; set; }
        public UserRole Role { get; set; }
        public Guid ForeinId { get; set; }

        internal void Update(User user)
        {
            Username = user.Username;
            Password = user.Password;
            Role = user.Role;
            ForeinId = user.ForeinId;
        }
    }
}
