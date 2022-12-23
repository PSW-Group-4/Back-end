using HospitalAPI.Dtos.NewsHeadlines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsHeadlines : ControllerBase
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            List<NewsHeadlinesDTO> list = new List<NewsHeadlinesDTO>();
            list.Add(new NewsHeadlinesDTO("Vest 1"));
            list.Add(new NewsHeadlinesDTO("Vest 2"));
            list.Add(new NewsHeadlinesDTO("Vest 3"));
            list.Add(new NewsHeadlinesDTO("Vest 4"));
            list.Add(new NewsHeadlinesDTO("Vest 5"));
            list.Add(new NewsHeadlinesDTO("Vest 6"));
            list.Add(new NewsHeadlinesDTO("Vest 7"));
            return Ok(list);
        }

    }
}
