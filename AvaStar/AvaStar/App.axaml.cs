using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;
using AvaStar.Common;
using AvaStar.Services;
using AvaStar.ViewModels;
using AvaStar.Views;
using Microsoft.Extensions.DependencyInjection;
using SukiUI;
using SukiUI.Dialogs;
using SukiUI.Toasts;
using System;

namespace AvaStar
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                //SukiTheme.GetInstance().ChangeBaseTheme(ThemeVariant.Dark);
                var services = new ServiceCollection();
                services.AddSingleton(desktop);
                var views = ConfigureViews(services);
                var provider = ConfigureServices(services);
                DataTemplates.Add(new ViewLocator(views));
                desktop.MainWindow = views.CreateView<MainWindowViewModel>(provider) as Window;
            }

            base.OnFrameworkInitializationCompleted();
        }

        private static SukiViews ConfigureViews(ServiceCollection services)
        {
            return new SukiViews()

                // Add main view
                .AddView<MainWindow, MainWindowViewModel>(services)

                // Add pages
                .AddView<HomeView, HomeViewModel>(services)
                .AddView<SettingView, SettingViewModel>(services);
        }

        private static ServiceProvider ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<ClipboardService>();
            services.AddSingleton<PageNavigationService>();
            services.AddSingleton<ISukiToastManager, SukiToastManager>();
            services.AddSingleton<ISukiDialogManager, SukiDialogManager>();

            return services.BuildServiceProvider();
        }
    }
}