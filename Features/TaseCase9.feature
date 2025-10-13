Feature: Search Product
    To verify that the product search function works correctly on Automation Exercise

@UI @Regression
Scenario: User Searches for a product successfully
    Given user navigates to "https://automationexercise.com/"
    Then home page title "Home" should be visible

    When user clicks on "Products" button
    Then products page title "ALL PRODUCTS" should be visible
    And user should see sale images

    When user enters a product name in the search input
    And clicks the search button
    Then user should be navigated to the search results page
    And title "SEARCHED PRODUCTS" should be visible
    And all products related to the searched keyword should be displayed
