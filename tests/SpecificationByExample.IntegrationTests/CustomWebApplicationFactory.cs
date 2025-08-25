using Microsoft.AspNetCore.Mvc.Testing;

namespace SpecificationByExample.IntegrationTests;

public class CustomWebApplicationFactory<TProgram> 
    : WebApplicationFactory<TProgram> where TProgram : class
{
   
}