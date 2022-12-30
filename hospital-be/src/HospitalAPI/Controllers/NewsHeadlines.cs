using System;
using HospitalAPI.Dtos.NewsHeadlines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HospitalLibrary.News;
using HospitalLibrary.Users.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsHeadlines : ControllerBase
    {
   
        private readonly INewsService _newsService;

        public NewsHeadlines(INewsService newsService)
        {
         
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult GetAllPublishedTitlesFromIntegrationAPI()
        {
            try
            {

                return Ok( _newsService.GetAllPublishedTitlesFromIntegrationAPIAsync().Result ) ;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
