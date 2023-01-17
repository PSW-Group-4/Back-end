using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using IntegrationAPI.Authorization;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationAPI.Dtos.BloodSupplies;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.Common;
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
        private readonly IConverter<Tender, TenderDto> _tenderConverter;
        private readonly IBloodBankService _bloodBankService;
        private readonly IProducer _producer;
        public TenderController(ITenderService tenderService, IConverter<Tender, TenderDto> tenderConverter, IBloodBankService bloodBankService, IProducer producer)
        {
            _tenderService = tenderService;
            _tenderConverter = tenderConverter;
            _bloodBankService = bloodBankService;
            _producer = producer;
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

        [Route("{id}"), HttpPut]
        public ActionResult GetById(Guid id)
        {
            return Ok(_tenderService.GetById(id));
        }
        [Route("active"), HttpGet]
        public ActionResult GetActive() {
            return Ok(_tenderService.GetActive());
        }

        [Route("{id}/winner/confirm"), HttpPost]
        public ActionResult ConfirmWinner(Guid id)
        {
            WinnerConfirmedEvent winnerConfirmedEvent = new(id);
            _tenderService.ConfirmWinner(winnerConfirmedEvent);
            Tender tender = _tenderService.GetById(winnerConfirmedEvent.AggregateId);
            foreach (Blood blood in tender.Blood)
            {
                ReceivedBloodDto dto = new(blood.BloodType.ToString(), blood.Amount);
                _producer.Send(JsonSerializer.Serialize(dto), "hospital.blood.supply.topic");
            }
            return Ok();
        }
        [Route("{tenderId}/winner/{bloodBankId}"), HttpPut]
        public ActionResult ChooseWinner(string tenderId, string bloodBankId) {
            BloodBank winner = _bloodBankService.GetByApiKey(bloodBankId);
            WinnerChosenEvent winnerChosenEvent = new( Guid.Parse(tenderId), winner);
            _tenderService.ChooseWinner(winnerChosenEvent);
             return Ok( );

        }
    }
}
