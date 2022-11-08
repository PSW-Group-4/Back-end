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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        public UserController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IMapper mapper)
        {
            _userService = userService;
            _addressService = addressService;
            _patientService = patientService;
            _mapper = mapper;
        }

        //POST api/user
        [HttpPost]
        public ActionResult RegisterPatient([FromBody] PatientRegistrationDto registrationDto)
        {
            try
            {
                var address = _mapper.Map<Address>(registrationDto.AddressRequestDto);
                var patient = _mapper.Map<Patient>(registrationDto);
                var user = _mapper.Map<User>(registrationDto.UserLoginDto);

                _addressService.Create(address);
                _patientService.RegisterPatient(patient, address.Id, registrationDto.ChoosenDoctorId,
                    registrationDto.AllergieIds);

                _userService.Create(user);
                //slanje maila (pozivanje servia koji salje mail)
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}
