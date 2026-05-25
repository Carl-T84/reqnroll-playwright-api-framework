using Microsoft.Playwright;

namespace ReqnrollPlaywrightApi.Clients;

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

    public async Task<IAPIResponse> PutAsync(string endpoint, object body)
    {
        return await _request.PutAsync(endpoint, new APIRequestContextOptions
        {
            DataObject = body
        });
    }       

     public async Task<IAPIResponse> DeleteAsync(string endpoint)
    {
        return await _request.DeleteAsync(endpoint);
    }  

    public async Task<IAPIResponse> PatchAsync(string endpoint, object body)
    {
        return await _request.PatchAsync(endpoint, new APIRequestContextOptions
        {
            DataObject = body
        });
    } 

}                      