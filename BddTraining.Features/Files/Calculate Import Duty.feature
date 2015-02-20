Feature: Calculate Import Duty
	In order to comply with regulatory requirements
	As a store owner
	I want to be able to calculate import duty for products

Scenario Outline: Calculate Import Duty
	Given I have the following product: <name>, $<price>, <isimported>
	When I calculate Import duty for the product
	Then The import duty returned should be equal to $<importduty>
Examples: 
	| name        | price | isimported | importduty | notes                                    |
	| "TV"        | 1000  | true       | 50         | 5% import duty for imported products     |
	| "Furniture" | 500   | false      | 0          | no import Duty for non imported products |