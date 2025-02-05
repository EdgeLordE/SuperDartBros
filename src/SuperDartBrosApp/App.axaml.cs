using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SuperDartBrosApp.Models;
using SuperDartBrosApp.ViewModels;
using SuperDartBrosApp.Views;
using System.Collections.Generic;

namespace SuperDartBrosApp;

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
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if(ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            var players = new List<Player>
            {
                new Player("Player1", 0),
                new Player("Player2", 0)
            };

            var gameSettings = new GameSettings(players);
            var mainView = new MainView(gameSettings); 

            singleViewPlatform.MainView = mainView;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
