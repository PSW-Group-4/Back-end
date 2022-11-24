using HospitalLibrary.Users.Model;

namespace HospitalAPI.Dtos.User
{
    public class UserDto
    {
        //public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
