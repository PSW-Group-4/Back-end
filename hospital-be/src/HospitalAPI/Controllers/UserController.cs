using AutoMapper;
using HospitalAPI.Dtos.User;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Core.Service.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _patientService = patientService;
            _mapper = mapper;
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
                var token = _userService.Authenticate(userLogin.Username, userLogin.Password);
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
    }
}
