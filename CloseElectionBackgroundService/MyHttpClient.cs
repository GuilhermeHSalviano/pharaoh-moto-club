using System.Net.Http;

namespace CloseElectionBackgroundService;


public class MyHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task GetFinishedElectionAsync()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "http://localhost:5064/elections"
        );

        var httpClient = _httpClientFactory.CreateClient();

        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        var response = await httpResponseMessage.Content.ReadAsStringAsync();

        Console.WriteLine(response);
    }
}