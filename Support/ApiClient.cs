using Microsoft.Playwright;

namespace Backend.Bdd.Tests.Support;

public class ApiClient
{
    private readonly IAPIRequestContext _request;

    public ApiClient(IAPIRequestContext request)
    {
        _request = request;
    }

    public async Task<IAPIResponse> GetAsync(string endpoint)
    {
        return await _request.GetAsync(endpoint);
    }

    public async Task<IAPIResponse> PostAsync(string endpoint, object body)
    {
        return await _request.PostAsync(endpoint, new APIRequestContextOptions
        {
            DataObject = body
        });
    }
}