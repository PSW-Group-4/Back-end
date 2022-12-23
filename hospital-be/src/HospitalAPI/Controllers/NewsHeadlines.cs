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
            list.Add(new NewsHeadlinesDTO("Vest: Jana kida Jana kida Jana kida Jana kida Jana kida"));
            list.Add(new NewsHeadlinesDTO("Vest: Dunja dominira"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovana gori"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovan je car"));

            list.Add(new NewsHeadlinesDTO("Vest: Jana kida"));
            list.Add(new NewsHeadlinesDTO("Vest: Dunja dominira"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovana gori"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovan je car"));

            list.Add(new NewsHeadlinesDTO("Vest: Jana kida"));
            list.Add(new NewsHeadlinesDTO("Vest: Dunja dominira"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovana gori"));
            list.Add(new NewsHeadlinesDTO("Vest: Jovan je car"));

            return Ok(list);
        }

    }
}
