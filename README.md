# SampleUITestFramework.Net

## What is this?
Simple test framework implemented in C#.

Technologies:
- C#
- Selenium Webdriver
- NUnit as test executor

## Purposes
- Build sample test framework
- Do simple tests on "BBC.com" web application

## Main features
- Extendable to test any typical Web App
- Extendable to support any browser
- Supports parallelization

## Components
- Models project. Contains business models of the App
- Page Objects project. Contains web pages models.
- Test project. Contains UI tests.

## How to launch?
- Install Chrome, Firefox browsers
- To run using Visual Studio:
  - Install Visual Studio
  - Open the solution
  - Build -> Build Solution
  - Open Test explorer: Test -> Windows -> Test explorer
  - Now tests should be discovered. If not, refer to https://stackoverflow.com/questions/25472286/nunit-tests-not-discovered-in-c-sharp-solution
  - Click "Run All"
