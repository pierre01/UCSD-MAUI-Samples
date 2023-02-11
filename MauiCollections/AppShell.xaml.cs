using MauiCollections.Views;

namespace MauiCollections;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(PersonDetailsView), typeof(PersonDetailsView));
	}
}
