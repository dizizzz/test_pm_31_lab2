@setup_feature
Feature: Customer Login and Withdraw Funds
  In order to withdraw funds
  As a customer
  I want to log in and perform a successful withdrawal

  Scenario: Successful login and withdrawal
    Given I am on the home page
    When I log in as "Hermoine Granger"
    And I withdraw "1"
    Then I should see a success message "Transaction successful"
