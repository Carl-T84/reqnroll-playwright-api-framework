using Microsoft.Playwright;

namespace Backend.Bdd.Tests.Support;

public class TestContext
{
    public IAPIResponse? Response { get; set; }
    public object? RequestBody { get; set; }
}