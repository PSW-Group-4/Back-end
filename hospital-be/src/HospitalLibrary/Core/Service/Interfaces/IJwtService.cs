using HospitalLibrary.Users.Model;
using Microsoft.AspNetCore.Http;

namespace HospitalLibrary.Core.Service.Interfaces
{
    public interface IJwtService
    {

        public string GenerateToken(User user);
        public User GetCurrentUser(System.Security.Principal.IPrincipal httpContextUser);
        public bool HasMatchingRoles(string expectedRoles, System.Security.Principal.IPrincipal httpContextUser);
    }
}