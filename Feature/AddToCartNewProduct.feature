Feature: Products
	In order to avoid a bad behavior
	As a guest user
	I want to add to cart a new product

@mytag
Scenario: Add to cart new product
	Given I have created a product in the shopping site via API	
	When I navigate to the page of the created product
	And I increase the quantity number to <number>
	And I click Add to cart button
	And I click on the Cart icon
	Then I verify that the user navigates to cart page
	And I validate that the product shows in the list
	And I validate that the price and count are correct
Examples: 
| number  |
| 7 |