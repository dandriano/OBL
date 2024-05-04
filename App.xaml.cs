using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls;
using OBL.ViewModels;

namespace OBL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            Ioc.Default.ConfigureServices(new ServiceCollection()
                                                .AddTransient<MemoViewModel>()
                                                .BuildServiceProvider());
        }
    }
}
