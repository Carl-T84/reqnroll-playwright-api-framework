Feature: Users API
Scenario: Get user by id
  When I request user with id 1
  Then the response status code should be 200
  And the response should contain username "Bret"