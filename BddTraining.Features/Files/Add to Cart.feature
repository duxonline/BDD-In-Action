Feature: Add To Cart
	In order to place an order
	As an online shopper
	I want to add products to my shopping cart

Scenario: Add A Product to Cart
	Given I have the following product:
	| name       | price  | isimported | type   |
	| Kindle     | 500    | true       | Normal |
	When I add the product to my cart
	Then My cart item should look like the following:
	| name     | price  | quantity |
	| Kindle   | 500    | 1        |