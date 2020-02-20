Feature: SearchHoodieProductsAndDetails
	In order to test search feature
	As a guest user
	I want to verify that users can search for Hoodie products and navigate to the detail page

@mytag
Scenario: Verify that users can search for Hoodie products and navigate to the detail page
	Given I have navigated to the homepage
	When I fill the search input with Hoodie
	And I press the Enter key within the search input
	And I Click on Hoodie with Pocket
	Then The product page for Hoodie with Pocket loads properly
