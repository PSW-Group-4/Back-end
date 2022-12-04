using RestSharp;

namespace IntegrationAPI.Communications.Pdf
{
    public class PdfSender
    {
        public static string SendPdf(string url, string path)
        {
            //"http://localhost:8080/bloodUsage/upload"
            RestClientOptions options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            RestClient client = new RestClient(options);
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            request.AddFile("file", path);
            var response = client.ExecuteAsync(request);
            return response.Result.ResponseStatus.ToString();

        }

    }
}
