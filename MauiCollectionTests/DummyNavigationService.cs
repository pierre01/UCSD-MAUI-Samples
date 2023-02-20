using MauiCollections.Services;

namespace MauiCollectionTests;

public class DummyNavigationService : INavigationService
{
    public Task GoToAsync(string state, bool animate, IDictionary<string, object> parameters)
    {
       return Task.CompletedTask;
    }

    public Task GoToAsync(string state, IDictionary<string, object> parameters)
    {
        return Task.CompletedTask;
    }

    public Task GoToAsync(string state, bool animate)
    {
        return Task.CompletedTask;
    }

    public Task GoToAsync(string state)
    {
        return Task.CompletedTask;
    }
}