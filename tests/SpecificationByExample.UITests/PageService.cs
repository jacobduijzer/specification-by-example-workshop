using SpecificationByExample.UITests.Pages;

namespace SpecificationByExample.UITests;

public interface IPageService
{
    HomePage HomePage { get; }
}

public class PageService(HomePage homePage) : IPageService
{
    public HomePage HomePage { get; } = homePage;
}