Feature: Simple Calculator
In order to avoid silly mistakes
As a math idiot
I want to be able to do simple calculations

    @unit
    Scenario: Add two numbers
        Given I have entered 50 into the calculator
        And I want to add 70 to it
        When I ask for the result
        Then the result should be 120

    @integration
    Scenario: Adding two numbers via an API
        Given I have a calculator API
        When I send a request to add 50 and 70
        Then the response should be 120

    @unit
    Scenario Outline: Adding numbers
        Given I have entered <first> into the calculator
        And I want to add <second> to it
        When I ask for the result
        Then the result should be <total>

        Examples:
          | first | second | total |
          | 12    | 5      | 17    |
          | 20    | 5      | 25    |

    @unit
    Scenario: Subtract two numbers
        Given I have entered 50 into the calculator
        And I want to subtract 20 from it
        When I ask for the result
        Then the result should be 30

    @unit
    Scenario Outline: Subtracting numbers
        Given I have entered <first> into the calculator
        And I want to subtract <second> from it
        When I ask for the result
        Then the result should be <total>

        Examples:
          | first | second | total |
          | 12    | 5      | 7     |
          | 20    | 5      | 25    |

    @ui
    Scenario Outline: Using the Web Calculator
        Given I have opened the web calculator
        When I enter <first> as the first number
        And I enter <second> as the second number
        When I click the '<operation>' button
        Then I can click the equals button
        And the result should be <total> on the screen

        Examples:
          | first | second | operation | total |
          | 12    | 5      | Add       | 17    |
          | 20    | 5      | Add       | 25    |
          | 20    | 5      | Subtract  | 15    |
          | 20    | 5      | Multiply  | 100   |
          | 20    | 5      | Divide    | 4     |