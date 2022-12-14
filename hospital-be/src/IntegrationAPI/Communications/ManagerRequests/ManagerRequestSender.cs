using IntegrationAPI.Dtos.BloodRequests;
using RestSharp;
using System.Text.Json;

namespace IntegrationAPI.Communications.ManagerRequests
{
    public class ManagerRequestSender
    {
        public static string SendRequest(ManagerBloodRequestDto dto)
        {
            RestClientOptions options = new RestClientOptions("http://localhost:8080/bloodrequests/manager_request")
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var body = JsonSerializer.Serialize<ManagerBloodRequestDto>(dto);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = client.ExecuteAsync(request);
            return response.Result.ResponseStatus.ToString();
        }
    }
}
