using CommunityToolkit.Mvvm.ComponentModel;
using MAUICommunications.ViewModels;
using System.Collections.ObjectModel;

namespace MAUICommunications.Views;

public partial class NetworkingPage : ContentPage
{
	public NetworkingPage()
	{
		InitializeComponent();
		this.BindingContext = new NetworkingPageViewModel();
	}
}