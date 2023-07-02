using System;
using System.Reflection;

[assembly:AssemblyVersionAttribute("2.0.1")]

namespace MauiApplicationModel;

// The example displays the following output:
//        This is version 2.0.1.0 of Example1.
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
        Assembly thisAssem = typeof(MauiProgram).Assembly;
        AssemblyName thisAssemName = thisAssem.GetName();

        Version ver = thisAssemName.Version;
		return builder.Build();


    }
}
