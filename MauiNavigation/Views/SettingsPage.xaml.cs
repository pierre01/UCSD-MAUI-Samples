using MauiNavigation.ViewModels;

namespace MauiNavigation.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel settings)
	{
		BindingContext = settings;
		InitializeComponent();
	}
}