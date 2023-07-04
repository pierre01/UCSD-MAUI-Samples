using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SearchPageWithHandler : ContentPage
{
	public SearchPageWithHandler(SearchPageWithHandlerViewModel viewModel)
	{
        BindingContext = viewModel;
        InitializeComponent();
        

    }

    private void TeamCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void personSearchHandler_PersonSelected(object sender, Models.Person e)
    {
        TeamCollectionView.SelectedItem = e;
    }
}