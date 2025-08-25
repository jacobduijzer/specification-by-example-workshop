using Reqnroll;

namespace SpecificationByExample.IntegrationTests;

[Binding, Scope(Tag = "integration")]
public class CalculatorStepDefinitions(
    ScenarioContext scenarioContext,
    CustomWebApplicationFactory<Program> factory)
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly ICalculatorApi _api = Refit.RestService.For<ICalculatorApi>(factory.CreateClient());

    [Given("I have a calculator API")]
    public void GivenIHaveACalculatorApi()
    {
        // DO NOTHING
    }

    [When("I send a request to add {int} and {int}")]
    public async Task WhenISendARequestToAddAnd(int numberOne, int numberTwo)
    {
        var result = await _api.Add(numberOne, numberTwo);
        scenarioContext.Add("result", result);
    }

    [Then("the response should be {int}")]
    public void ThenTheResponseShouldBe(int expectedResult)
    {
        Assert.Equal(expectedResult, scenarioContext.Get<int>("result"));
    }
}