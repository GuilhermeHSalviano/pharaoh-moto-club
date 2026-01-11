using Microsoft.VisualBasic;

namespace CloseElectionBackgroundService;

public class MyHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public MyHttpClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    var httpRequestMessage = new HttpRequestMessage(
        HttpMethod.Get,
        
    );

}