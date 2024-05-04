using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using OBL.ViewModels;
using OBL.Views;

namespace OBL
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                /*
                .RegisterPopups()
                .RegisterViewModels()
                .RegisterViews()
                */
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif 

            return builder.Build();
        }

        /*
        public static MauiAppBuilder RegisterPopups(this MauiAppBuilder builder)
        {
            builder.Services.AddTransientPopup<ActivityPopupView, ActivityPopupViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MemoViewModel>();

            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MemoView>();
            builder.Services.AddSingleton<MainPage>();

            return builder;
        }
        */
    }
}
