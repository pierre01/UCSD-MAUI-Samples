using CommunityToolkit.Maui;
using MauiNavigation.ViewModels;
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
            .RegisterViews()
            .RegisterViewModels()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            }).ConfigureEssentials(essentials =>
            {
                essentials
                    .AddAppAction("PopUpsPage", "Popups Page", icon: "popup_icon")
                    .AddAppAction("ToastAndSnackBarPage", "Toast and Snacks", icon: "popup_icon")
                    .OnAppAction(App.HandleAppActions);
            });


        return builder.Build();
	}



    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<SearchPageViewModel>();
        mauiAppBuilder.Services.AddTransient<SearchPageWithHandlerViewModel>();
        mauiAppBuilder.Services.AddSingleton<SettingsPageViewModel>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddTransient<PopUpsPage>();
        mauiAppBuilder.Services.AddTransient<SearchPage>();
        mauiAppBuilder.Services.AddTransient<SearchPageWithHandler>();
        mauiAppBuilder.Services.AddTransient<ToastAndSnackBarPage>();
        mauiAppBuilder.Services.AddSingleton<SettingsPage>();
        return mauiAppBuilder;
    }
}
