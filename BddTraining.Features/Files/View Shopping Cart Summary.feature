Feature: View Shopping Cart Summary
	In order to place an order
	As an online shopper
	I want to view my shopping cart summary

Scenario: View Shopping Cart Summary
	Given I have the following two products:
	| name            | price | type   | isimported |
	| Kindle          | 500   | Normal | true       |
	| Design Patterns | 50    | Books  | false      |
	When I add them to my cart
	Then My cart summary should look like following:
	| name            | price | quantity | subtotal | Tax |
	| Kindle          | 500   | 1        | 500      | 75  |
	| Design Patterns | 50    | 1        | 50       | 0   |
	And The total price is $550
	And The tax total is $75
	And The grant total is $625