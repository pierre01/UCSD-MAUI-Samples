using CommunityToolkit.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ZXing.Net.Maui.Controls;

namespace MauiGraphics;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseBarcodeReader()
            .UseSkiaSharp()

            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            })
        #region fix
            .ConfigureMauiHandlers(h =>
            {
                //h.AddHandler(typeof(ZXing.Net.MAUI.Controls.Camerabase))
            });
		#endregion

		return builder.Build();
	}
}
