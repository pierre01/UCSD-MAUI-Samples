namespace MauiCollections.Services;

public interface INavigationService
{
    Task GoToAsync(string state, bool animate, IDictionary<string, object> parameters);
    Task GoToAsync(string state, IDictionary<string, object> parameters);
    Task GoToAsync(string state, bool animate);
    Task GoToAsync(string state);
}