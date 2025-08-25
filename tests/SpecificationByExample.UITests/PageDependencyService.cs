using Microsoft.Playwright;
using Reqnroll;

namespace SpecificationByExample.UITests;

public interface IPageDependencyService
{
    Task<IPage> Page { get; }
}

public class PageDependencyService : IPageDependencyService, IDisposable
{
    public PageDependencyService(Task<IPage> page)
    {
        Page = page;
        Page.Result.SetDefaultTimeout(240000);
    }

    public void Dispose()
    {
        Page.Result.Context.Browser?.CloseAsync();
    }

    public Task<IPage> Page { get; }
}