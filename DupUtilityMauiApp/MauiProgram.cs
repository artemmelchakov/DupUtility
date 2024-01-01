using Microsoft.Extensions.Logging;
using DupUtilityMauiApp.Data;
using CommunityToolkit.Maui;
using DupUtilityMauiApp.Data.Services.Interfaces;
using DupUtilityMauiApp.Data.Services;

namespace DupUtilityMauiApp;

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
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<IFileSystemService, FileSystemService>();

		return builder.Build();
	}
}
