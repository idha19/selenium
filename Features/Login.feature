Feature: Login User with correct email and password
    To verify that user can login with email and password correctly

    Background:
        Given user on automation exercise web home page
        When user clicks on Signup / Login button
        Then verify Login to your account is visible

    @Login @UI 
    Scenario: User login with email and password
        When user logs in with email <email> and password <password>
        Then user clicks login button
        And verify login message <message> is visible

        Examples:
            | email                | password       | message                                      |
            | tase.case1@gmail.com | tase.case1     | Logged in as username                        |
            | test1@gmail.com        | 123          | Your email or password is incorrect!         |

    @Login @UI
    Scenario: User logout successfully
        When user logs in with email tase.case1@gmail.com and password tase.case1
        Then user clicks login button
        And verify that Logged in as username is visible
        When user clicks Logout button
        Then verify that user is navigated to login page