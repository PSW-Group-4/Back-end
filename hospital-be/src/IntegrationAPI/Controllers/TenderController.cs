using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Tenders.Model;
using IntegrationLibrary.Tenders.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;
        private readonly TenderConverter tenderConverter;

        public TenderController(ITenderService tenderService, TenderConverter tenderConverter)
        {
            _tenderService = tenderService;
            this.tenderConverter = tenderConverter;
        }

        [HttpPost]
        public ActionResult Create(TenderDto dto)
        {
            _tenderService.Create(tenderConverter.Convert(dto));
            return Ok();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_tenderService.GetAll());
        }
    }
}
