using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SearchWithHandlerPage : ContentPage
{
	public SearchWithHandlerPage()
	{
        BindingContext = new SearchPageViewModel();
        InitializeComponent();
	}

    private void OnTeamSelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}