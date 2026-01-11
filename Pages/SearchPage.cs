using Microsoft.Playwright;
using System.Threading.Tasks;

namespace NorthumbriaAutomation.Pages;

public class SearchPage
{
    private readonly IPage _page;

    public SearchPage(IPage page)
    {
        _page = page;
    }

    public IPage Page => _page;

    public async Task NavigateToHomeAsync()
    {
        await _page.GotoAsync("https://www.northumbria.nhs.uk/");
    }

    public async Task EnterSearchTermAsync(string term)
    {
        await _page.Locator("//*[@id=\"search-query-carousel-40618\"]").FillAsync(term);
    }

    public async Task ClickSearchButtonAsync()
    {
        await _page.ClickAsync("button[aria-label='Search']");
        // Wait for search results to load
        await _page.WaitForSelectorAsync("div#page-results", new PageWaitForSelectorOptions { Timeout = 10000 });
    }

    public ILocator SearchResults => _page.Locator("div#page-results > div");
}
