using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using IntegrationAPI.Authorization;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.Tendering.DomainEvents.Subtypes;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : Controller
    {
        private readonly ITenderService _tenderService;
        private readonly IConverter<Tender, TenderDto> tenderConverter;

        public TenderController(ITenderService tenderService, IConverter<Tender, TenderDto> tenderConverter)
        {
            _tenderService = tenderService;
            this.tenderConverter = tenderConverter;
        }


        [HttpPost]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult Create(TenderDto dto)
        {
            TenderCreatedEvent tenderCreatedEvent = dto.Deadline == null ? new TenderCreatedEvent(BloodConverter.Convert(dto.Blood), null) :  new TenderCreatedEvent(BloodConverter.Convert(dto.Blood), DateTime.Parse(dto.Deadline));
            _tenderService.Create(tenderCreatedEvent);
            return Ok();
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_tenderService.GetAll());
        }
        [Route("active"), HttpGet]
        public ActionResult GetActive() {
            return Ok(_tenderService.GetActive());
        }

        [Route("{id}/winner/confirm"), HttpPut]
        public ActionResult ConfirmWinner(Guid id)
        {
            WinnerConfirmedEvent winnerConfirmedEvent = new(id);
            _tenderService.ConfirmWinner(winnerConfirmedEvent);
            return Ok();
        }
    }
}
