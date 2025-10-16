Feature: User Registration
    To verify that user can register, login, and delete account successfully

    @Register @UI @Regression
    Scenario: User registers a new account successfully
        Given user on automation exercise web home page

        When user clicks on "Signup / Login" button
        Then verify "New User Signup!" is visible

        When user enters name and email address
        And clicks "Signup" button
        Then verify that "ENTER ACCOUNT INFORMATION" is visible

        When user fills account details with valid data
        And selects newsletter and offers checkboxes
        And fills address details
        And clicks "Create Account" button
        Then verify that "ACCOUNT CREATED!" is visible

        When user clicks "Continue" button
        Then verify that "Logged in as username" is visible

        When user clicks "Delete Account" button
        Then verify that "ACCOUNT DELETED!" is visible
        And clicks "Continue" button after delete