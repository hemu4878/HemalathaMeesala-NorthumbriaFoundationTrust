Feature: Search Functionality
  As a Northumbria foundation user
  I want to be able to search for a variety of information on the public website
  So that I can find relevant results

  @search
  Scenario Outline: Search for different types of information
    Given I am on the Northumbria NHS website
    When I enter "<searchTerm>" in the search field
    And I click the search button
    Then I should see search results related to "<searchTerm>"

    Examples:
      | searchTerm    |
      | contact       |
      | appointment   |
      | services      |
      | departments   |
