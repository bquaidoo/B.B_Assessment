Feature: AutomationPractice


@Regression
Scenario: Sign in with no credentials
	Given I am on automation practice site
	 And I click on login button
	When I attempt to sign in with no credentials
	Then I should get error message 'An email address required.'
	 And I close browser


@Regression
Scenario: Sign in with email and Empty password
	Given I am on automation practice site
	 And I click on login button
	 And I enter Email address 'abc@abc.com'
	When I attempt to sign in with no credentials
	Then I should get error message 'Password is required.'
	 And I close browser


@Regression
Scenario: Sign in with password and Empty email
	Given I am on automation practice site
	 And I click on login button
	 And I enter Password 'mypassword123'
	When I attempt to sign in with no credentials
	Then I should get error message 'An email address required.'
	 And I close browser


@Regression
Scenario: Sign in with with incorrect credentials
	Given I am on automation practice site
	 And I click on login button
	 And I enter Email address 'abc@abc.com'
	 And I enter Password 'mypassword123'
	When I attempt to sign in with no credentials
	Then I should get error message 'Authentication failed.'
	 And I close browser