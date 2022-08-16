namespace MauiGeoLocation
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
                }).ConfigureEssentials(essentials =>
                {
                    essentials.UseMapServiceToken("Bing-Maps-API-Token");
                }); 

            return builder.Build();
        }
    }
}