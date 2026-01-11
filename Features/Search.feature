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

  @search @no-results
  Scenario: Search with no results found
    Given I am on the Northumbria NHS website
    When I enter "xyzqwerty123nonexistent" in the search field
    And I click the search button
    Then I should see a no results message

  @search @empty-search
  Scenario: Empty search handling
    Given I am on the Northumbria NHS website
    When I leave the search field empty
    And I click the search button and wait for response
    Then I should see an appropriate message for empty search

  @search @special-characters
  Scenario Outline: Search with special characters
    Given I am on the Northumbria NHS website
    When I enter "<specialSearchTerm>" in the search field
    And I click the search button and wait for response
    Then the search should handle special characters gracefully

    Examples:
      | specialSearchTerm |
      | @contact          |
      | test&appointment  |
      | "emergency"       |
      | <script>test      |
      | £100 fee          |
