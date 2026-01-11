using System.Net;
using System.Net.Http;

namespace CloseElectionBackgroundService;


public class MyHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task GetAndCloseFinishedElectionAsync()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "http://localhost:5064/elections"
        );

        var httpClient = _httpClientFactory.CreateClient();

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if(httpResponseMessage.StatusCode != HttpStatusCode.NoContent)
        {
            var electionId = await httpResponseMessage.Content.ReadAsStringAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Put,
                $"http://localhost:5064/elections/{electionId}"
            );

            await httpClient.SendAsync(request);
        }
    }
}
