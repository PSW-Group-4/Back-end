using AutoMapper;
using HospitalLibrary;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Feedbacks.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using HospitalAPI.Dtos.Feedback;

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
        
        //GET api/feedback/published
        //Goes only to patient
        [HttpGet("published")]
        public ActionResult GetAllPublished()
        {
            return Ok(_mapper.Map<IEnumerable<FeedbackPatientResponseDto>>(_feedbackService.GetAllPublished()));
        }

        
        //TODO "Change to patch"
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

        //TODO "Change to patch"
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


        //POST api/feedback
        [HttpPost]
        public ActionResult Create([FromBody]FeedbackRequestDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            _feedbackService.Create(feedback);
            //TODO
            //return CreatedAtAction("GetById", new { id = feedback.Id }, feedback);
            return Ok(_mapper.Map<FeedbackPatientResponseDto>(feedback));
        }
    }
}