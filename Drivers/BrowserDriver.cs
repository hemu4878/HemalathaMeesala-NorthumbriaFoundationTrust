using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Playwright;

namespace NorthumbriaAutomation.Drivers;

public class BrowserDriver
{
    private IBrowser _browser;
    private IBrowserContext _context;

    public BrowserDriver()
    {
        InitializeBrowserAsync().Wait();
    }

    private async Task InitializeBrowserAsync()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        string browserName = config["Browser"];

        var playwright = await Playwright.CreateAsync();

        _browser = browserName switch
        {
            "firefox" => await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }),
            "edge" => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Channel = "msedge", Headless = true }),
            _ => await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }),
        };

        _context = await _browser.NewContextAsync();
    }

    public async Task<IPage> CreateNewPageAsync()
    {
        return await _context.NewPageAsync();
    }

    public async Task CloseAsync()
    {
        if (_context != null)
            await _context.CloseAsync();
        if (_browser != null)
            await _browser.CloseAsync();
    }
}
