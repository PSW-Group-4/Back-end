using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using Microsoft.IdentityModel.Tokens;

namespace IntegrationLibrary.Utilities
{
        public class JwtService
        {
            private readonly IBloodBankRepository _bloodBankRepository;

            public JwtService(IBloodBankRepository bloodBankRepository)
            {
                _bloodBankRepository= bloodBankRepository;
            }
            public static string GenerateToken(BloodBank bloodBank)
            {
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4"));
                SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

                Claim[] claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, bloodBank.Name),
                    new Claim(ClaimTypes.Email, bloodBank.EmailAddress.ToString()),
                    new Claim(ClaimTypes.Role, "BloodBank"),
                };

                JwtSecurityToken token = new("http://localhost:5000/",
                    "http://localhost:5000/",
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        
            public static IEnumerable<Claim> GetClaimsFromToken(string token) {
                JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken;
                return jwtToken.Claims;
            }

            public static string GetEmailFromToken(string token)
            {
                return GetClaimsFromToken(token).FirstOrDefault(claim => claim.Type == ClaimTypes.Email).Value;
            }

            public static string GetRoleFromToken(string token)
            {
                return GetClaimsFromToken(token).FirstOrDefault(claim => claim.Type == ClaimTypes.Role).Value;
            }
        }
    
}