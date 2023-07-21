using CommunityToolkit.Maui;
using MediatorWithMaui.Repositories;
using MediatorWithMaui.ViewModels;
using MediatorWithMaui.Views;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace MediatorWithMaui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        // register mediatR
        builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // register DI for Views and ViewModels
        builder.Services.AddSingleton<HomeView>();
        builder.Services.AddSingleton<HomeViewModel>();

        builder.Services.AddSingleton<CreateTodoView>();
        builder.Services.AddSingleton<CreateTodoViewModel>();

        builder.Services.AddSingleton<EditTodoView>();
        builder.Services.AddSingleton<EditTodoViewModel>();

        builder.Services.AddSingleton<DashboardView>();
        builder.Services.AddSingleton<DashboardViewModel>();

        // setup DB
        var dbName = "todo.db3";
        var dbPath = FileAccessHelper.GetLocalFilePath(dbName);
        builder.Services.AddSingleton<TodoRepository>(s => ActivatorUtilities.CreateInstance<TodoRepository>(s, dbPath));

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
