using Refit;

namespace SpecificationByExample.IntegrationTests;


public interface ICalculatorApi
{
   [Get("/add?numberOne={numberOne}&numberTwo={numberTwo}")] 
   Task<int> Add(int numberOne, int numberTwo);
}