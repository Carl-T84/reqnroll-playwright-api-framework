using Backend.Bdd.Tests.Support;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Reqnroll;

namespace Backend.Bdd.Tests.StepDefinitions;

[Binding]
public class UserSteps
{
    private readonly ApiClient _apiClient;
    private readonly TestContext _testContext;

    public UserSteps(ScenarioContext scenarioContext)
    {
        _apiClient = scenarioContext.Get<ApiClient>();
        _testContext = scenarioContext.Get<TestContext>();
    }

    [When(@"I request user with id (.*)")]
    public async Task WhenIRequestUserWithId(int userId)
    {
        _testContext.Response = await _apiClient.GetAsync($"/users/{userId}");
    }

    [Then(@"the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        _testContext.Response!.Status.Should().Be(expectedStatusCode);
    }

    [Then(@"the response should contain username ""(.*)""")]
    public async Task ThenTheResponseShouldContainUsername(string expectedUsername)
    {
        var body = await _testContext.Response!.TextAsync();
        var json = JObject.Parse(body);

        json["username"]!.ToString().Should().Be(expectedUsername);
    }
}