using Camera.MAUI;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using MauiCamera.ViewModels;
using MauiCamera.Views;
using Microsoft.Extensions.Logging;

namespace MauiCamera;

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

            .UseMauiCameraView()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.RegisterServices();
        builder.RegisterViewModels();
        builder.RegisterViews();
        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
        mauiAppBuilder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
        mauiAppBuilder.Services.AddSingleton<IPreferences >(Preferences.Default);
        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<SettingsPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddSingleton<SettingsPage>();
        return mauiAppBuilder;
    }
}