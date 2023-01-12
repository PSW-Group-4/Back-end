using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.Exceptions;
using Microsoft.AspNetCore.Authorization;
using HospitalAPI.Dtos.Renovation;
using HospitalAPI.Dtos.RenovationSession;
using HospitalLibrary.RenovationSessionAggregate.Services.Interfaces;


namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class RenovationSessionStatisticsController : ControllerBase
    {
        private readonly IRenovationSessionStatisticsService _renovationStatisticsService;
        private readonly IMapper _mapper;
        
        public RenovationSessionStatisticsController(IRenovationSessionStatisticsService renovationStatisticsService, IMapper mapper)
        {
            _renovationStatisticsService = renovationStatisticsService;
            _mapper = mapper;
        }

        [HttpGet("average-number-went-back")]
        public ActionResult GetAverageNumberOfTimesWentBackPerStep()
        {
            return Ok(_renovationStatisticsService.GetAverageNumberOfTimesWentBackPerStep());
        }

        [HttpGet("average-time-spent-on-steps")]
        public ActionResult GetAverageTimeSpentOnStepsInSession()
        {
            return Ok(_renovationStatisticsService.GetAverageTimeSpentOnStepsInSession());
        }

        [HttpGet("average-time-spent-on-steps-timeframe/{start},{end}")]
        public ActionResult GetAverageTimeSpentOnStepsInSessionForTimeframe(String start, String end)
        {
            return Ok(_renovationStatisticsService.GetAverageTimeSpentOnStepsInSessionForTimeframe(DateTime.Now.AddHours(int.Parse(start) -DateTime.Now.Hour ), DateTime.Now.AddHours(int.Parse(end) -DateTime.Now.Hour )));
        }

        [HttpGet("finished-unfinished-statistics")]
        public ActionResult GetFinishedAndUnfinishedSessionStatistic()
        {
            return Ok(_renovationStatisticsService.GetFinishedAndUnfinishedSessionStatistic());
        }

        [HttpGet("statistics-for-table")]
        public ActionResult GetFinishedSessionStatisticsForTable()
        {
            return Ok(_renovationStatisticsService.GetFinishedSessionStatisticsForTable());
        }

        [HttpGet("statistics-where-session-was-left-off")]
        public ActionResult GetNumberOfSessionLeftOffOnEachStep()
        {
            return Ok(_renovationStatisticsService.GetNumberOfSessionLeftOffOnEachStep());
        }
    }
}