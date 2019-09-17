Feature: Add To Cart
	In order to place an order
	As an online shopper
	I want to add products to my shopping cart

Scenario: Add to Cart
	Given I have the following product:
	| name                 | price | isimported | type |
	| Domain Driven Design | 500   | false      | Book |
	When I add the product to my cart
	Then My cart item should look like the following:
	| name                 | price | quantity |
	| Domain Driven Design | 500   | 1        |