using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IntegrationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            IEnumerable<News> news = _service.GetAll();
            return Ok(news);
        }
    }
}
