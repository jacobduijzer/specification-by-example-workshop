using Microsoft.Playwright;

namespace SpecificationByExample.UITests.Pages;

public class HomePage(IPageDependencyService pageDependencyService)
{
    public async Task GoToPageAsync(string address)
    {
        await pageDependencyService.Page.Result.GotoAsync(address);
    }
    
    public async Task EnterFirstNumber(int number)
    {
        var numberInput = Locate("#number1").First;
        await numberInput.FillAsync(number.ToString());
    }
    
    public async Task EnterSecondNumber(int number)
    {
        var numberInput = Locate("#number2").First;
        await numberInput.FillAsync(number.ToString());
    }
    
    public async Task ClickButton(string operation)
    {
        var button = operation switch
        {
            "+" => Locate("#button-add").First,
            "-" => Locate("#button-subtract").First,
            "*" => Locate("#button-multiply").First,
            "/" => Locate("#button-divide").First,
            "=" => Locate("#button-equals").First,
            _ => throw new Exception("Unknown operation")
        };
        await button.ClickAsync();
    }
    
    public async Task<int> Result()
    {
        var valueInput = await Locate("#value-label").First.TextContentAsync();
        return int.Parse(valueInput!);
    }

    private ILocator Locate(string selector) => pageDependencyService.Page.Result.Locator(selector);


   
}