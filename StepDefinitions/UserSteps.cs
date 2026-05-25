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

    [Given(@"I have a valid post request")]
    public void GivenIHaveAValidPostRequest()
    {
        _testContext.RequestBody = new
        {
            title = "Reqnroll Test",
            body = "Playwright API automation",
            userId = 1
        };
    }

    [When(@"I create a new post")]
    public async Task WhenICreateANewPost()
    {
        _testContext.Response = await _apiClient.PostAsync(
            "/posts",
            _testContext.RequestBody!);
    } 


    [When(@"I get the comments for posts with id 5")]
    public async Task CarlTest1()
    {
        _testContext.Response = await _apiClient.GetAsync("/posts/1/comments");
    }

    [Then(@"the response code must be 200")]
    public void ThenTheResponseCodeMustBe200()
    {
        _testContext.Response!.Status.Should().Be(200);
    }

    [Then(@"the response body should contain ""(.*)""")]
    public async Task ThenTheResponseBodyShouldContain(string expectedContent)
    {
        var body = await _testContext.Response!.TextAsync();
        body.Should().Contain(expectedContent);
    }
}