using AutoMapper;
using HospitalAPI.Dtos.Feedback;
using HospitalAPI.Dtos.User;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Service;
using HospitalLibrary.Patients.Model;
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
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        //POST api/user
        [HttpPost]
        public ActionResult Create([FromBody]PatientRegistrationDto registrationDto)
        {
            var user = _mapper.Map<User>(registrationDto.UserLoginDto);
            var address = _mapper.Map<Address>(registrationDto.AddressRequestDto);
            var patient = _mapper.Map<Patient>(registrationDto);
            //_feedbackService.Create(feedback);
            //return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
            return Ok();
        }
    }
}
