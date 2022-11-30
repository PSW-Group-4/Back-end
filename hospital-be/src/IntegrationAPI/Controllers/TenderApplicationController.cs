using AutoMapper;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderApplicationController : ControllerBase
    {
        private readonly ITenderApplicationService _service;
        private readonly IMapper _mapper;

        public TenderApplicationController(ITenderApplicationService service, IMapper mapper)
        {

            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<TenderApplication> tenderApplications = _service.GetAll();
            return Ok(tenderApplications);
        }
    }
}
