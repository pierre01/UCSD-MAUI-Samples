namespace MauiControls
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.ConfigureMauiHandlers(handlers =>
{
#if ANDROID
	// handlers.AddHandler(typeof(TimePicker), typeof(Platforms.Android.SpinTimePickerHandler));
#endif
}) ;
            return builder.Build();
        }
    }
}