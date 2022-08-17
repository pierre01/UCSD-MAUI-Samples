using ZXing.Net.Maui;

namespace MauiGraphics;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseBarcodeReader()
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
