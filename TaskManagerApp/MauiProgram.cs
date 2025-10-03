using Microsoft.Extensions.Logging;
using TaskManagerApp.Services;
using TaskManagerApp.ViewModels;
using TaskManagerApp.Views;

namespace TaskManagerApp
{
    public static class MauiProgram
    {
        public static class ServiceProviderHolder
        {
            public static IServiceProvider? ServiceProvider { get; set; }
        }
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register Services (Singleton - one instance for the entire app)

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "tasks.db3");
            builder.Services.AddSingleton<Services.ITaskService>(s => new Services.TaskService(dbPath));
            builder.Services.AddSingleton<Services.IQuoteService, Services.QuoteService>();


            // Register ViewModels (Transient - new instance each time)
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddTaskViewModel>();

            // Register Views (Transient)
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddTaskPage>();



            var app = builder.Build();

            ServiceProviderHolder.ServiceProvider = app.Services;
            return app;
        }
    }
}
