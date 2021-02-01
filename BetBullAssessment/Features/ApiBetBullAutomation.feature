Feature: ApiBetBullAutomation


@Regression
Scenario: SuccessfullRegistration (Api)
	Given I have endpoint 'register' and i register with email 'eve.holt@reqres.in' and password 'pistol' and i save content as 'result' and response code as 'StatusCode'
	 When response 'StatusCode' is '200'
	Then the 'result' returns all the following message body:
	| id | token             |
	| 4  | QpwL5tke4Pnpja7X4 |

@Regression
Scenario: Un-SuccessfullRegistration (Api)
	Given I have endpoint 'register' and i register with email 'eve.holt@reqres.in' and password '' and i save content as 'result' and response code as 'StatusCode'
	 When response 'StatusCode' is '400'
	Then the 'result' returns all the following msg:
    | msg              |
    | Missing password |

@Regression
Scenario: GetAllUsers
	Given I have endpoint 'users' and i save my content as 'result' and my response code as 'StatusCode'
	 When response 'StatusCode' is '200'
	Then the 'result' returns all the following body:
	| page | per_page | total | total_pages | 
	| 1    | 6        | 12    | 2           |