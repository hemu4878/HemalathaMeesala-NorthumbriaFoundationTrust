using NorthumbriaAutomation.Drivers;
using Reqnroll;
using Microsoft.Playwright;

namespace NorthumbriaAutomation.Hooks;

[Binding]
public sealed class Hooks
{
    private static BrowserDriver? _browserDriver;
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        _browserDriver = new BrowserDriver();
    }

    [BeforeScenario(Order = 1)]
    public async Task BeforeScenario()
    {
        var page = await _browserDriver.CreateNewPageAsync();
        _scenarioContext["Page"] = page;
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        if (_scenarioContext.TryGetValue("Page", out IPage page))
        {
            await page.CloseAsync();
        }
    }
}
