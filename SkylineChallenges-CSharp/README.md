# Skyline Challenges - CSharp
Three coding exercises are contained in this project. All three have code for you to fill in and/or change as well as corresponding test cases.

The goal of each challenge is to get all unit tests to pass successfully.  The unit tests may not be modified unless specified in the exercise.

## Process
1. Create a fork of this repository
1. Implement changes to pass all tests in all three Challenges
1. Push all changes back out to GitHub

## Challenges
### Fake Binary Number Generator
The `ConvertToFakeBinary` method in the `FakeBinary` class will take in a string of variable length made up of digits from 0-9 and convert it to a pseudo-binary string.

If a number comes in from 0-4, it should be a 0.  If it's 5-9, it should be a 1.  

Sample conversion: 113968212627731429 => 000111000101100001

A number of test cases are already present to validate your method.

### REST APIs
A RESTful API of users is available to be consumed.  The corresponding fields can be found on the `User` model in this folder.

The task here is to complete three methods:
* `GetUsers()`
* `SetDivisionAndRegionsForUsers(users)`
* `AddUsersToAgeGroup(users)`

Once these three methods are properly implemented, all tests in `TestProcessUsers` should pass.

### Refactoring
The `FileProcessor` class has one primary method: `Process()`.  This method needs some help (and please note that this was intentional, my coding isn't _quite_ this bad.)

But first, a few of the tests need to be filled in.  Ensure all unit tests are completed and are passing successfully given the existing code, _then_ start refactoring the `Process()` method.

New types/methods/enums/etc. can be added to this folder to help the `Process()` method.  The point here is to clean up this method as much as possible to allow it to be readable, explainable, and maintainable.
