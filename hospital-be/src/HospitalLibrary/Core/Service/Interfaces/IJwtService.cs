using HospitalLibrary.Users.Model;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IJwtService
    {

        public string GenerateToken(User user);
    }
}