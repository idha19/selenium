Feature: Login User with correct email and password
    To verify that user can login with email and password correctly

    Background:
        Given user on automation exercise web home page
        When user clicks on "Signup / Login" button
        Then verify "Login to your account" is visible

    @Login @UI @Regression
    Scenario: User login with correct email and password successfully
        When user logs in with valid email and valid password
        Then user clicks "login" button
        And verify that "Logged in as username" is visible

    @Login @UI @Negative
    Scenario: User login with incorrect email and password
        When user logs in with invalid email "test1@gmail.com" and invalid password "123"
        Then user clicks "login" button
        And verify error 'Your email or password is incorrect!' is visible

    @Login @UI @Negative
    Scenario: User logout successfully
        When user logs in with valid email and valid password
        Then user clicks "login" button
        And verify that "Logged in as username" is visible
        When user clicks "Logout" button
        Then verify that user is navigated to login page