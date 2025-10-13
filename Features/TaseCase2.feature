Feature: Login User with correct email and password
    To verify that user can login with email and password correctly

    @Login @UI @Regression
    Scenario: User login with correct email and password successfuly
        Given user navigates to url "https://automationexercise.com/"
        Then verify that home page is visible successfully

        When user clicks on "Signup / Login" button
        Then verify "Login to your account" is visible

        When user logs in with email "testuser@example.com" and password "Password123"
        Then user clicks "login" button
        And verify that "Logged in as username" is visible
        
        When user clicks "Delete Account" button
        Then verify that "ACCOUNT DELETED!" is visible