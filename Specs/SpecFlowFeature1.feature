Feature: User Trading
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario:  Person opens a trade account
	Given Person applies for an account with tax id "66-999999999", bank account number "88888888", and routing number "444444444"
	And Person has signed stock market trade agreements
	Then there exists an account for Person 
	And Person's account has signed stock market trade agreements

Scenario: A sale
	Given seller has 5 shares of XYZ stock with $0
	When seller is selling 1 share of XYZ stock at $10 per share
	Then the saletrade queue has 1 share of XYZ stock at $10 per share

