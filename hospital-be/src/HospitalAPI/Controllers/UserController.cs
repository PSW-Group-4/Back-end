using System;
using AutoMapper;
using HospitalAPI.Dtos.Auth;
using HospitalAPI.Dtos.User;
using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.AcountActivation.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Service.Interfaces;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Constants;
using IntegrationLibrary.Common;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IAcountActivationService _acountActivationService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IAddressService addressService,
            IPatientService patientService, IAcountActivationService acountActivationService, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _patientService = patientService;
            _acountActivationService = acountActivationService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<User> GetAll()
        {
            var users = _userService.GetAll();
            return users;
        }

        //POST api/user/registerPatient
        [HttpPost]
        [Route("[action]")]
        public ActionResult RegisterPatient([FromBody] PatientRegistrationDto registrationDto)
        {
            try
            {
                
                if (!_patientService.isEmailUnique(registrationDto.Email))
                {
                    return Conflict("Email not unique");
                }

                if (!_userService.IsUsernameUnique(registrationDto.UserLoginDto.Username))
                {
                    return Conflict("Username taken");
                }

                var address = _mapper.Map<Address>(registrationDto.AddressRequestDto);
                address.Id = Guid.NewGuid();

                Patient patient = new Patient(Guid.NewGuid(), registrationDto.Name, registrationDto.Surname,
                    registrationDto.Birthdate, registrationDto.Gender, address, registrationDto.Jmbg,
                    new Email(registrationDto.Email), registrationDto.PhoneNumber, new BloodType(registrationDto.BloodType.BloodGroup, registrationDto.BloodType.RhFactor));
                
                _patientService.RegisterPatient(patient, registrationDto.ChoosenDoctorId,
                    registrationDto.AllergieIds);

                User user = new User(registrationDto.UserLoginDto.Username,new Password(registrationDto.UserLoginDto.Password),UserRole.Patient);

                AcountActivationInfo info = _userService.RegisterPatient(user, patient.Id);
                //slanje maila (pozivanje servia koji salje mail)
                _acountActivationService.SendVerificationLinkEmail(info);

                return Ok(info);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (ValueObjectValidationFailedException exception)
            {
                return BadRequest("Value object error");
            }

        }

        //POST api/user/loginUser/patient
        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult LoginPublic([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var token = _userService.AuthenticatePublic(userLogin.Username, userLogin.Password);
                return Ok(new JwtDto(token));
            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (BadPasswordException)
            {
                return Unauthorized("Bad password");
            }
            catch (AccountNotActivatedException)
            {
                return StatusCode(403);
            }
            catch (UnauthorizedException)
            {
                return Unauthorized("Only patients can login from public app");
            }
            catch (UserIsBlockedException)
            {
                return Unauthorized("Your account has been blocked");
            }
            catch (ValueObjectValidationFailedException)
            {
                return Unauthorized("Bad password");
            }
            catch (Exception)
            {
                return BadRequest("Unknown error");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult LoginPrivate([FromBody] UserLoginDto userLogin)
        {
            try
            {
                var token = _userService.AuthenticatePrivate(userLogin.Username, userLogin.Password);
                return Ok(new JwtDto(token));
            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (BadPasswordException)
            {
                return Unauthorized("Bad password");
            }
            catch (UnauthorizedException)
            {
                return Unauthorized("Only managers and doctors can login from public app");
            }
            catch (ValueObjectValidationFailedException)
            {
                return Unauthorized("Bad password");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult ActivateAccount([FromBody] AccountActivationDto activationInformation)
        {
            if (activationInformation == null)
            {
                return BadRequest();
            }

            try
            {
                _userService.ActivateAccount(activationInformation.Token, activationInformation.Id);
                return Ok();
            }
            catch (NotFoundException e)
            {
                return NotFound("User not found");
            }
            catch (AcountAlreadyActivatedException e)
            {
                return BadRequest("Your account is already activated");
            }
            catch (TokensDoNotMatchException e)
            {
                return Unauthorized("Tokens do not match");
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult AuthorizeIntegrationApi([FromBody] IntegrationAuthorizationDto dto)
        {
            if (_jwtService.HasMatchingRoles(dto.ExpectedRoles, HttpContext.User))
            {
                return Ok();
            }
            return Unauthorized();
        }

 

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Manager")]
        public ActionResult GetAllSuspiciousUsers()
        {
            return Ok(_userService.GetAllSuspiciousUsers().Select(sp => new SuspiciousUserDTO(sp.Username, sp.IsBlocked, sp.NumberOfSuspiciousActivitiesInRecentPeriod())).ToList());
        }


        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Manager")]
        public ActionResult SuspiciousCount()
        {
            return Ok(Constants.MinSuspiciousActivityCount);
        }

        [HttpPatch("block-user/{username}")]

        [Authorize(Roles = "Manager")]
        public ActionResult BlockUser([FromRoute] string username)
        {
            try
            {

                _userService.BlockUser(username);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (UserIsAlreadyBlockedException)
            {
                return Conflict("User is already blocked");
            }
            catch (UserCanNotBeBlocked)
            {
                return Conflict("User can not be blocked");
            }
        }

        [HttpPatch("unblock-user/{username}")]

        [Authorize(Roles = "Manager")]
        public ActionResult UnblockUser([FromRoute] string username)
        {
            try
            {
                _userService.UnblockUser(username);
                return Ok();

            }
            catch (NotFoundException)
            {
                return NotFound("User not found");
            }
            catch (UserIsNotBlockedException)
            {
                return Conflict("User was not blocked so it can not be unblocked");
            }
        }


    }
}
