using AutoMapper;
using HospitalAPI.Controllers.Dtos.Feedback;
using HospitalLibrary;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(IFeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        //GET: api/feedback
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_feedbackService.GetAll());
        }

        //GET api/feedback/public/2
        [HttpGet("public/{id}")]
        public ActionResult SetPublic([FromRoute]Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                _feedbackService.SetPublic(feedback);
                return Ok(feedback);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //GET api/feedback/private/2
        [HttpGet("private/{id}")]
        public ActionResult SetPrivate([FromRoute]Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                _feedbackService.SetPrivate(feedback);
                return Ok(feedback);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }

        //GET api/feedback/accepted
        [HttpGet("accepted")]
        public ActionResult GetAllAccepted()
        {
            return Ok(_feedbackService.GetAllApproved());
        }

        //POST api/feedback
        [HttpPost]
        public ActionResult Create([FromBody]FeedbackRequestDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            _feedbackService.Create(feedback);
            //return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
            return Ok(feedback);
        }
    }
}