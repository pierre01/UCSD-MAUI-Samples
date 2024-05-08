using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SearchPage : ContentPage
{
    public SearchPage()
    {
        BindingContext = new SearchPageViewModel();
        InitializeComponent();
    }



    private void OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (e.OldTextValue != null && e.OldTextValue.Length >= 1 && string.IsNullOrEmpty(e.NewTextValue))
        {
            var viewModel = (SearchPageViewModel)BindingContext;
            viewModel.ClearSearchCommand.Execute(e.NewTextValue);
        }

    }
}