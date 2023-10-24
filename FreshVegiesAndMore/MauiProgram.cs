using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;

namespace FreshVegiesAndMore
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                 .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                 .ConfigureViews()
                .ConfigureViewModels()
                .ConfigureServices()
                .ConfigureHandlers()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AppShell>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder ConfigureViews(this MauiAppBuilder builder)
        {

            //account Views
           

            // other views
           

            return builder;
        }

        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {
            // account viewmodels
            

            // other viewmodels
          

            return builder;
        }

        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            //App Services
         
           

            // Other Services
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            return builder;


        }

        public static MauiAppBuilder ConfigureHandlers(this MauiAppBuilder builder)
        {
            return builder.ConfigureMauiHandlers(handlers =>
            {



            });


        }
    }
}
