Feature: Users API

Scenario: Get user by id
  When I request user with id 1
  Then the response status code should be 200
  And the response should contain username "Bret"

  Scenario: Create a new post
    Given I have a valid post request
    When I create a new post
    Then the response status code should be 201

    Scenario: Test response body in comments
    When I get the comments for posts with id 5
    Then the response code must be 200
    And the response body should contain "non et atque\noccaecati deserunt quas accusantium unde odit nobis qui voluptatem\nquia voluptas consequuntur itaque dolor\net qui rerum deleniti ut occaecati"