using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SearchPage : ContentPage
{
	public SearchPage()
	{
        BindingContext = new SearchPageViewModel();
		InitializeComponent();
    }

    private void OnTeamSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {

    }
}