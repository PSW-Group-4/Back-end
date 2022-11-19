using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBankNews.Service;
using IntegrationLibrary.BloodBanks.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [Route("GetArchived"), HttpGet]
        public ActionResult GetArchived()
        {
            IEnumerable<News> archived = _service.GetArchived();
            return Ok(archived);
        }
        [Route("GetPublished"), HttpGet]
        public ActionResult GetPublished()
        {
            IEnumerable<News> published = _service.GetPublished();
            return Ok(published);
        }
        [Route("GetPending"), HttpGet]
        public ActionResult GetPending()
        {
            IEnumerable<News> pending = _service.GetPending();
            return Ok(pending);
        }
        [Route("Publish"), HttpPost]
        public ActionResult PublishNews(string id) {
            News news = _service.GetById(Guid.Parse(id));
            news.IsPublished = true;
            news.IsArchived = false;
            return Ok(_service.Update(news));
        }
        [Route("Archive"), HttpPost]
        public ActionResult ArchiveNews(string id)
        {
            News news = _service.GetById(Guid.Parse(id));
            news.IsPublished = false;
            news.IsArchived = true;
            return Ok(_service.Update(news));
        }

    }
}
