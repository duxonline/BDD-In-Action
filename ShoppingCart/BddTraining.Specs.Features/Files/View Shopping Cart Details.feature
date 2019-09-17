Feature: View Shopping Cart Details
	In order to place an order
	As an online shopper
	I want to view my shopping cart details before placing it

Scenario: View Shopping Cart Details
	Given I have the following products added to my cart:
	| name            | price | type   | isimported |
	| Kindle          | 500   | Normal | true       |
	| Design Patterns | 50    | Book   | false      |
	When I view my shopping cart details
	Then My cart details should look like following:
	| name            | price | quantity | subtotal | Tax | note                                  |
	| Kindle          | 500   | 1        | 500      | 75  | sales tax $50 + $25 import duty       |
	| Design Patterns | 50    | 1        | 50       | 0   | sales tax exempted and no import duty |
	And The total price is $550
	And The tax total is $75
	And The grant total is $625