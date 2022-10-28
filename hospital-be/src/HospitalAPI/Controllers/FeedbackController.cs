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

        //GET api/feedback/publish/2
        [HttpGet("publish/{id}")]
        public ActionResult Publish([FromRoute]Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                _feedbackService.Publish(feedback);
                return Ok(feedback);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //GET api/feedback/hide/2
        [HttpGet("hide/{id}")]
        public ActionResult Hide([FromRoute]Guid id)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                _feedbackService.Hide(feedback);
                return Ok(feedback);
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
        }

        //GET api/feedback/published
        [HttpGet("published")]
        public ActionResult GetAllPublished()
        {
            return Ok(_feedbackService.GetAllPublished());
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