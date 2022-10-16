Feature: Calculator

Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	And operation must be +

Scenario: Subtract two numbers
	Given the first number is 50,5
	And the second number is 70,51
	When the two numbers are subtracted
	Then the result should be -20,010000000000005
	And operation must be -

Scenario: Multiplication two numbers
	Given the first number is 123,123
	And the second number is 321,321
	When the two numbers are multiplied
	Then the result should be 39562,00548300001
	And operation must be *

Scenario: Dividing two numbers
	Given the first number is 52,5
	And the second number is 74,5
	When the two numbers are divided
	Then the result should be 0,7046979865771812
	And operation must be /

Scenario: Dividing with error
	Given the first number is 1554
	And the second number is 0
	When the two numbers are divided
	Then operation must be /
	Then the result should be |b| < 10e-8
	And with error

Scenario: Invalid input first arg
	Given the first number is asdr
	And the second number is 123
	When the two numbers are multiplied
	Then the result should be Неверный формат входного аргумента
	And with error

Scenario: Invalid input second arg
	Given the first number is 789
	And the second number is gr-er
	When the two numbers are added
	Then the result should be Неверный формат входного аргумента
	And with error

Scenario: Invalid input empty args
	When the two numbers are subtracted
	Then the result should be Неверный формат входного аргумента
	And with error
