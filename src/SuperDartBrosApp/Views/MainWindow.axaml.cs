using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ReactiveUI;
using SuperDartBrosApp.Models;
using System.Collections.Generic;

namespace SuperDartBrosApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //Cursor = new Cursor(StandardCursorType.None); Für Raspberry Pi später ändern
    }

    private void BtnStart_Click(object? sender, RoutedEventArgs e)
    {
        if(string.IsNullOrWhiteSpace(TBPlayer1.Text) || string.IsNullOrWhiteSpace(TBPlayer2.Text))
        {
            return;
        }
        var players = new List<Player>

        {
            new Player(TBPlayer1.Text, 0),
            new Player(TBPlayer2.Text, 0)
        };
        var mainGameSettings = new GameSettings(players);
        Content = mainGameSettings;
    }
}
