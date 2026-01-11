using TechTalk.SpecFlow;
using NorthumbriaAutomation.Pages;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace NorthumbriaAutomation.StepDefinitions;

[Binding]
public class SearchSteps
{
    private readonly ScenarioContext _scenarioContext;
    private SearchPage _searchPage;

    public SearchSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        var page = _scenarioContext["Page"] as IPage;
        _searchPage = new SearchPage(page);
    }

    [Given(@"I am on the Northumbria NHS website")]
    public async Task GivenIAmOnTheWebsite()
    {
        await _searchPage.NavigateToHomeAsync();
    }

    [When(@"I enter ""(.*)"" in the search field")]
    public async Task WhenIEnterSearchTerm(string term)
    {
        await _searchPage.EnterSearchTermAsync(term);
    }

    [When(@"I click the search button")]
    public async Task WhenIClickSearchButton()
    {
        await _searchPage.ClickSearchButtonAsync();
    }

    [Then(@"I should see search results related to ""(.*)""")]
    public async Task ThenIShouldSeeSearchResults(string expected)
    {
        // Wait for the results page to load
        await _searchPage.Page.WaitForSelectorAsync("div#page-results", new PageWaitForSelectorOptions { Timeout = 15000 });

        // Get the page content
        var pageContent = await _searchPage.Page.ContentAsync();
        
        // Check if the expected term is in the page
        pageContent.Should().Contain(expected, $"search results should contain '{expected}'");
    }
}
