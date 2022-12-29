using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Repository;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace HospitalLibrary.Core.Service
{
    public class JwtService : IJwtService
    {
        //private readonly IConfiguration _config;

        private readonly IUserRepository _userRepository;

        public JwtService(IConfiguration config, IUserRepository userRepository)
        {
            //_config = config;
            _userRepository = userRepository;
        }
        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("personId", user.PersonId.ToString())
            };

            var token = new JwtSecurityToken("http://localhost:16177/",
              "http://localhost:16177/",
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        
        public User GetCurrentUser(System.Security.Principal.IPrincipal httpContextUser)
        {
            var identity = httpContextUser.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;
                string username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                User user = _userRepository.GetByUsername(username);

                if (user != null)
                {
                    return user;
                }
                //Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value;
                //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value*/
                throw new InvalidJwtException();
            }
            throw new InvalidJwtException();
        }

        public bool HasMatchingRoles(string expectedRoles, System.Security.Principal.IPrincipal httpContextUser)
        {
            if (httpContextUser.Identity is not ClaimsIdentity identity) return false;
            
            var userClaims = identity.Claims;
            var roles = userClaims.Where(o => o.Type == ClaimTypes.Role).Select(r => r.Value).ToList();
                
            var expectedRolesSeparate = expectedRoles.Split(",").ToList();
                
            return AreIdenticalLists(roles, expectedRolesSeparate);
        }

        private static bool AreIdenticalLists(List<string> list1, List<string> list2)
        {
            var firstNotSecond = list1.Except(list2).ToList();
            var secondNotFirst = list2.Except(list1).ToList();
            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }
    }
}