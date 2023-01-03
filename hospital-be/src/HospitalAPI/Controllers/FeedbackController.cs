using AutoMapper;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HospitalAPI.Dtos.Feedback;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Users.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using HospitalLibrary.Core.Service.Interfaces;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper,
            IUserService userService, IJwtService jwtService)
        {
            _feedbackService = feedbackService;
            _userService = userService;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        //GET: api/feedback
        //Goes only to manager
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<FeedbackManagerResponseDto>>(_feedbackService.GetAll()));
        }

        //GET api/feedback/2
        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                return Ok(feedback);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
        //GET api/feedback/published
        //Goes only to patient
        [HttpGet("published")]
        public ActionResult GetAllPublished()
        {
            return Ok(_mapper.Map<IEnumerable<FeedbackPatientResponseDto>>(_feedbackService.GetAllPublished()));
        }

        //PATCH api/feedback/publish/2
        [HttpPatch("publishhide/{id}")]
        [Authorize(Roles = "Manager")]
        public ActionResult PublishHide([FromRoute] Guid id, [FromBody] JsonPatchDocument feedbackModel)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                feedback.Publish(feedback, feedbackModel);
                _feedbackService.Update(feedback);

                return Ok(feedback);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(FeedbackAlreadyPublishedOrHidden)
            {
                return BadRequest();
            }
        }
        
        //POST api/feedback
        [HttpPost]
        [Authorize(Roles = "Patient")]
        public ActionResult Create([FromBody]FeedbackRequestDto feedbackDto)
        {
            feedbackDto.PatientId = _jwtService.GetCurrentUser(HttpContext.User).PersonId;
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
        }
    }
}