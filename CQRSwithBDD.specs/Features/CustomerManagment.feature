Feature: Cutomer
Link to a feature: [Customer](CQRSwithBDD.specs/Features/Customer.feature)

@mytag
Scenario: Add new customer
	Given I have the following customer:
	| Id | FirstName | LastName | DateOfBirth  | PhoneNumber   | email                  | BankAccountNumber | Active |
	| 10000000-0000-0000-0000-000000000000  | Akbar     | Dizaji   | 9 March 1993 | +98938xxxx429 | Dizaji.akbar@yahoo.com | IS774588123       | true    |
	When the customer is created
	Then the result should have the following values:
	| Id | FirstName | LastName | DateOfBirth  | PhoneNumber   | email                  | BankAccountNumber | Active |
	| 10000000-0000-0000-0000-000000000000  | Akbar     | Dizaji   | 9 March 1993 | +98938xxxx429 | Dizaji.akbar@yahoo.com | IS774588123       | true   |