using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using MauiCamera.ViewModels;
using MauiCamera.Views;
using Microsoft.Extensions.Logging;

namespace MauiCamera
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitCamera()
                .UseMauiCommunityToolkit()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.RegisterViewModels();
            builder.RegisterViews();
            builder.RegisterServices();
            return builder.Build();
        }
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<IFolderPicker>(FolderPicker.Default);
            mauiAppBuilder.Services.AddSingleton<IFileSaver>(FileSaver.Default);
            mauiAppBuilder.Services.AddSingleton<IPreferences>(Preferences.Default);
            mauiAppBuilder.Services.AddSingleton<IFileSystem>(FileSystem.Current);
            return mauiAppBuilder;
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<SettingsPageViewModel>();
            mauiAppBuilder.Services.AddTransient<MainPageViewModel>();

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<MainPage>();
            mauiAppBuilder.Services.AddSingleton<SettingsPage>();
            return mauiAppBuilder;
        }
    }
}
