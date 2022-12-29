using System;
using HospitalAPI.Dtos.NewsHeadlines;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using HospitalLibrary.Users.Model;

namespace HospitalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsHeadlines : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _integrationEndpoint;

        public NewsHeadlines()
        {
            _httpClient = new HttpClient();
            _integrationEndpoint = "http://localhost:45488/api/News/GetPublished";
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {

            using var httpResponse = await _httpClient.GetAsync(_integrationEndpoint, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    return Ok(serializer.Deserialize<List<NewsHeadlinesDTO>>(jsonReader));
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;

        }

    }
}
