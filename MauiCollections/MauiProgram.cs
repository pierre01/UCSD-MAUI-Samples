using MauiCollections.Services;
using MauiCollections.ViewModels;
using MauiCollections.Views;

namespace MauiCollections;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .RegisterServices()
            .RegisterViewModels()
            .RegisterViews()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
		mauiAppBuilder.Services.AddSingleton<IPersonDataProvider,PersonDataProvider>();
		mauiAppBuilder.Services.AddSingleton<IHomeDataProvider,HomeDataProvider>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
 		mauiAppBuilder.Services.AddSingleton<CarouselPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<PersonListViewModel>();
        mauiAppBuilder.Services.AddTransient<PersonDetailsViewModel>();
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<PersonListView>();
        mauiAppBuilder.Services.AddTransient<PersonDetailsView>();
        mauiAppBuilder.Services.AddSingleton<CarouselViewPage>();
        return mauiAppBuilder;
    }
}
