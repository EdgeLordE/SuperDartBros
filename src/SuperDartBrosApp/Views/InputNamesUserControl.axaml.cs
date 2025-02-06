using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SuperDartBrosApp.Models;
using System.Collections.Generic;

namespace SuperDartBrosApp;

public partial class InputNamesUserControl : UserControl
{
    public InputNamesUserControl()
    {
        InitializeComponent();
    }

    private void BtnStart_Click(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TBPlayer1.Text) || string.IsNullOrWhiteSpace(TBPlayer2.Text))
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