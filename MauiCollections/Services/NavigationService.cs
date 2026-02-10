namespace MauiCollections.Services;

public class NavigationService : INavigationService
{
    public Task GoToAsync(string state, bool animate, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, animate, parameters);
    }

    public Task GoToAsync(string state, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, parameters);
    }

    public Task GoToAsync(string state, bool animate)
    {
        return Shell.Current.GoToAsync(state, animate);
    }

    public Task GoToAsync(string state)
    {
        return Shell.Current.GoToAsync(state);
    }
}