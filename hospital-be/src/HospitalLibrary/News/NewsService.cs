using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HospitalAPI.Dtos.NewsHeadlines;
using Newtonsoft.Json;

namespace HospitalLibrary.News
{
   public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _integrationEndpoint;

        public NewsService()
        {
        _httpClient = new HttpClient();
        _integrationEndpoint = "http://localhost:45488/api/News/GetPublished";
        }

        public async Task<List<NewsHeadlinesDTO>> GetAllPublishedTitlesFromIntegrationAPIAsync()
        {
            using var httpResponse = await _httpClient.GetAsync(_integrationEndpoint, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode();

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    return serializer.Deserialize<List<NewsHeadlinesDTO>>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    throw new Exception("JSON can deserialize");
                }
            }
            else
            {
                throw new Exception("Error");
            }

        }
    }


    
}
