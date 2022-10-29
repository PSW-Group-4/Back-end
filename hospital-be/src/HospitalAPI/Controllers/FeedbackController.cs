using AutoMapper;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HospitalAPI.Dtos.Feedback;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

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


        //TODO "Change to patch"
        //GET api/feedback/publish/2
        /*[HttpGet("publish/{id}")]
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
        }*/

        //PATCH api/feedback/publish/2
        [HttpPatch("publishhide/{id}")]
        public ActionResult PublishHide([FromRoute] Guid id, [FromBody] JsonPatchDocument feedbackModel)
        {
            try
            {
                var feedback = _feedbackService.GetById(id);
                _feedbackService.PublishHide(feedback, feedbackModel);
                return Ok(feedback);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        //POST api/feedback
        [HttpPost]
        public ActionResult Create([FromBody]FeedbackRequestDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            _feedbackService.Create(feedback);
            return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
        }
    }
}