using Microsoft.Extensions.DependencyInjection;
using Reqnroll;

namespace SpecificationByExample.UITests;

[Binding, Scope(Tag = "ui")]
public class CalculatorStepDefinitions(CustomWebApplicationFactory<Program> fixture)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private IPageService _pageService => 
        fixture.Services.GetRequiredService<IPageService>();

    [Given("I have opened the web calculator")]
    public async Task GivenIHaveOpenedTheWebCalculator()
    {
        await _pageService.HomePage.GoToPageAsync(fixture.ServerAddress);
        await _pageService.HomePage.Screenshot("OpenedCalculator");
    }

    [When("I enter {int} as the first number")]
    public async Task WhenIEnterAsTheFirstNumber(int number)
    {
        await _pageService.HomePage.EnterFirstNumber(number);
    }

    [When("I enter {int} as the second number")]
    public async Task WhenIEnterAsTheSecondNumber(int number)
    {
        await _pageService.HomePage.EnterSecondNumber(number);
    }
    
    [When("I click the {string} button")]
    public async Task WhenIClickTheButton(string operation)
    {
        var button = operation switch
        {
            "Add" =>  _pageService.HomePage.ClickButton("+"),
            "Subtract" => _pageService.HomePage.ClickButton("-"),
            "Multiply" => _pageService.HomePage.ClickButton("*"),
            "Divide" => _pageService.HomePage.ClickButton("/"),
            _ => throw new Exception("Unknown operation")
        };

        await button;
    }

    [Then("I can click the equals button")]
    public async Task ThenICanClickTheEqualsButton()
    {
        await _pageService.HomePage.ClickButton("=");
    }

    [Then("the result should be {int} on the screen")]
    public async Task ThenTheResultShouldBeOnTheScreen(int expectedResult)
    {
        var result = await _pageService.HomePage.Result();
        Assert.Equal(expectedResult, result);
    }

   
}