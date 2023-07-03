using CommunityToolkit.Maui;
using MauiNavigation.Views;

namespace MauiNavigation;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureEssentials(essentials =>
            {
                essentials
                    .AddAppAction("popups_page", "popups Page", icon: "popup_icon")
                    .AddAppAction("toast_page", "Toast and Snacks")
                    .OnAppAction(App.HandleAppActions);
            });


        return builder.Build();
	}

    public static void HandleAppActions(AppAction appAction)
    {
        App.Current.Dispatcher.Dispatch(async () =>
        {
            var page = appAction.Id switch
            {
                "popups_page" => new PopUpsPage(),
                "toast_page" => new ToastAndSnackBarPage(),
                _ => default(Page)
            };

            if (page != null)
            {
                await Application.Current.MainPage.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });
    }
}
