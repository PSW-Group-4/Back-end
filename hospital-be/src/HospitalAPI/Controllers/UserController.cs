using AutoMapper;
using HospitalAPI.Dtos.Feedback;
using HospitalAPI.Dtos.User;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAddressService _addressService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public UserController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IMapper mapper, IConfiguration config)
        {
            _userService = userService;
            _addressService = addressService;
            _patientService = patientService;
            _mapper = mapper;
            _config = config;
        }

        //POST api/user/registerPatient
        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterPatient([FromBody] PatientRegistrationDto registrationDto)
        {
            try
            {
                var address = _mapper.Map<Address>(registrationDto.AddressRequestDto);
                var patient = _mapper.Map<Patient>(registrationDto);
                var user = _mapper.Map<User>(registrationDto.UserLoginDto);

                patient.Address = address;
                patient.AddressId = address.Id;
                _patientService.RegisterPatient(patient,  registrationDto.ChoosenDoctorId,
                    registrationDto.AllergieIds);

                _userService.RegisterPatient(user, patient.Id);
                //slanje maila (pozivanje servia koji salje mail)
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //POST api/user/loginUser
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult Login([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var user = _userService.Authenticate(userLogin.Username, userLogin.Password);
                var token = Generate(user);
                return Ok(token);
            }
            catch(NotFoundException)
            {
                return NotFound("User not found");
            }
            catch(BadPasswordException)
            {
                return Unauthorized("Bad password");
            }
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //Otprilike ovako nekako mozes iz tokena da izvuces claims npr username
        /*private UserLoginDto GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null)
            {
                var userClaims = identity.Claims;

                return new UserLoginDto
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    //Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }*/
    }
}
