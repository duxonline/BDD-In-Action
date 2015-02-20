Feature: Calculate Basic Sales Tax
	In order to comply with regulatory requirements
	As a store owner
	I want to calculate sales tax for products

Scenario Outline: Calculate Basic Sales Tax
	Given There is a product with a price of $<price> and Its type is <type>
	When I calculate sales tax for the product
	Then The tax returned should be $<tax>
Examples: 
	| price | type    | tax | notes                          |
	| 100   | Normal  | 10  | charge 10% for normal products |
	| 300   | Books   | 0   | books exempted                 |
	| 600   | Food    | 0   | food exempte                   |
	| 900   | Medical | 0   | medical products exempted      |