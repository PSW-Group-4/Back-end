using AutoMapper;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationAPI.Communications.Producer;
using System.Text.Json;
using System.Web.Mvc;
using IntegrationAPI.Authorization;
using IntegrationLibrary.Common;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Service;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;
using IntegrationAPI.Communications.SharedStorage;

namespace IntegrationAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class BloodRequestController : ControllerBase
    {
        private readonly IBloodRequestService _service;
        private readonly IMapper _mapper;
        private readonly IProducer bloodRequestProducer;
        private readonly IBloodBankService bloodBankService;
        private readonly ISftpService sftpService;
        private IBloodRequestService bloodRequestService;
        private IBloodBankService bloodBankService1;
        private IProducer producer;

        public BloodRequestController(IBloodRequestService service, IBloodBankService bloodBankService, IProducer bloodRequestProducer, ISftpService sftpService)
        {
            _service = service;
            this.bloodBankService = bloodBankService;
            this.bloodRequestProducer = bloodRequestProducer;
            this.sftpService = sftpService;
        }

        public BloodRequestController(IBloodRequestService bloodRequestService, IBloodBankService bloodBankService1, IProducer producer)
        {
            this.bloodRequestService = bloodRequestService;
            this.bloodBankService1 = bloodBankService1;
            this.producer = producer;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [AllowAnonymous]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager, Doctor")]
        public ActionResult GetAll()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetAll();
            return Ok(bloodRequests);
        }

        [Microsoft.AspNetCore.Mvc.Route("unapproved"), Microsoft.AspNetCore.Mvc.HttpGet]
        [AllowAnonymous]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GetUnapproved()
        {
            IEnumerable<BloodRequest> bloodRequests = _service.GetUnapproved();
            return Ok(bloodRequests);
        }

        [Microsoft.AspNetCore.Mvc.Route("manage"), Microsoft.AspNetCore.Mvc.HttpPost]
        [AllowAnonymous]
        [ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult Manage(BloodRequestEditDto bloodRequestDto) {
            BloodRequest bloodRequest = _service.GetById(bloodRequestDto.Id);
            bloodRequest.IsApproved = bloodRequestDto.IsApproved;
            bloodRequest.ManagerId = bloodRequestDto.ManagerId;
            if(bloodRequestDto.IsApproved)
            {
                bloodRequest.Status = BloodRequestStatus.APPROVED_BY_MANAGER;
                BloodRequestMessageDto messageDto = new(bloodRequest.Id, bloodRequest.Blood.BloodType.ToString(), bloodRequest.Blood.Amount, bloodRequest.SendOnDate, bloodRequest.IsUrgent);
                bloodRequestProducer.Send(JsonSerializer.Serialize(messageDto), "blood.requests.topic");
            } else
            {
                bloodRequest.Status = BloodRequestStatus.REJECTED_BY_MANAGER;
                bloodRequest.RejectionComment = bloodRequestDto.RejectionComment;
            }
            return Ok(_service.Update(bloodRequest));
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [AllowAnonymous]
        [ExternalAuthorizationFilter(ExpectedRoles = "Doctor")]
        public ActionResult Create([FromBody] BloodRequestsCreateDto bloodRequestDto)
        {
            BloodRequest bloodRequest = new()
            {
                Blood = BloodConverter.Convert(bloodRequestDto.BloodDto),
                DoctorId = bloodRequestDto.DoctorId,
                Reasons = bloodRequestDto.Reasons,
                IsUrgent = bloodRequestDto.IsUrgent,
                SendOnDate = bloodRequestDto.SendOnDate,
                Status = BloodRequestStatus.PENDING_APPROVAL
            };
            return Ok(_service.Create(bloodRequest));
        }
        [Microsoft.AspNetCore.Mvc.Route("report/{begining}/{end}"), Microsoft.AspNetCore.Mvc.HttpPut]
        //[AllowAnonymous]
        //[ExternalAuthorizationFilter(ExpectedRoles = "Manager")]
        public ActionResult GenerateUrgentBloodRequestReportForDateRange(DateTime begining, DateTime end)
        {
           string path = _service.GenerateUrgentRequestReportForDateRange(begining, end, bloodBankService.GetAll());
            string[] name = path.Split("blood supply");
            sftpService.UploadFile(path,"Urgent blood supply "+ name[1]);
            return Ok();
        }
    }
}

