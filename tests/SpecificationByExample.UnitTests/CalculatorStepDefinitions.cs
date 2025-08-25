using Reqnroll;

namespace SpecificationByExample.UnitTests;

[Binding, Scope(Tag = "unit")]
public class CalculatorStepDefinitions
{
    private Calculator.Calculator _calculator = new();
    private double _result;

    [Given("I have entered {int} into the calculator")]
    public void GivenIHaveEnteredIntoTheCalculator(int numberOne)
    {
        _calculator.Number(numberOne);
    }
    
    [Given("I want to add {int} to it")]
    public void GivenIWantToAddToIt(int numberTwo)
    {
        _calculator.Add(numberTwo);
    }

    [Given("I want to subtract {int} from it")]
    public void GivenIWantToSubtractIt(int numberTwo)
    {
        _calculator.Subtract(numberTwo);
    }
        
    [When("I ask for the result")]
    public void WhenIAskForTheResult()
    {
       _result = _calculator.Equals();
    }
        
    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        Assert.Equal(result, _result);
    }
}