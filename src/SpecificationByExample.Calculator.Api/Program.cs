using SpecificationByExample.Calculator;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/add", (int numberOne, int numberTwo) =>
{
    Calculator calculator = new();
    return calculator
        .Number(numberOne)
        .Add(numberTwo)
        .Equals();
});

app.Run();

public partial class Program { } // for integration tests