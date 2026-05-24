using Microsoft.Playwright;
using Reqnroll;

namespace Backend.Bdd.Tests.Support;

[Binding]
public class Hooks
{
    private static IPlaywright? _playwright;
    private static IAPIRequestContext? _requestContext;

    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        _playwright = await Playwright.CreateAsync();

        _requestContext = await _playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = "https://jsonplaceholder.typicode.com",
            ExtraHTTPHeaders = new Dictionary<string, string>
            {
                { "Accept", "application/json" }
            }
        });
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var apiClient = new ApiClient(_requestContext!);
        var testContext = new TestContext();

        _scenarioContext.Set(apiClient);
        _scenarioContext.Set(testContext);
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        if (_requestContext != null)
            await _requestContext.DisposeAsync();

        _playwright?.Dispose();
    }
}