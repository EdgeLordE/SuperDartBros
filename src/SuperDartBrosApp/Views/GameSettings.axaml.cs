using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SuperDartBrosApp.Models;
using SuperDartBrosApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace SuperDartBrosApp;

public partial class GameSettings : UserControl
{
    public ObservableCollection<Player> Players { get; } = new ObservableCollection<Player>();

    public GameSettings(IEnumerable<Player> players)
    {
        InitializeComponent();

        foreach(var player in players)
        {
            Players.Add(player);
        }

        DataContext = this;
        CheckPlayersCount();
    }

    private void BtnStart_Click(object? sender, RoutedEventArgs e)
    {
        var mainView = new MainView(); // Player mitgeben
        Content = mainView;
    }

    private void DeletePlayer_Click(object? sender, RoutedEventArgs e)
    {
        if(sender is Button button && button.DataContext is Player playerToDelete)
        {
            Players.Remove(playerToDelete);
        }
        CheckPlayersCount();
    }

    private void AddPlayer_Click(object? sender, RoutedEventArgs e)
    {
        if(Players.Count < 2)
        {
            var newPlayer = new Player { Name = "Neuer Spieler" };
            Players.Add(newPlayer);

            if(Players.Count == 2)
            {
                AddPlayerButton.IsEnabled = false;
            }
        }
        CheckPlayersCount();
    }


    private void AddBot_Click(object? sender, RoutedEventArgs e)
    {
        if(Players.Count < 2)
        {
            var bot = new Player
            {
                Name = GetRandomBotName(),
                IsBot = true
            };
            Players.Add(bot);

            UpdateTextBoxesForBots();

            if(Players.Count == 2)
            {
                AddBotButton.IsEnabled = false;
            }
            CheckPlayersCount();
        }
    }

    private string GetRandomBotName()
    {
        var botNames = new List<string> { "PEmil", "Zen", "Gaul", "Bumper", "Zap" };
        var random = new Random();
        return botNames[random.Next(botNames.Count)];
    }

    private void UpdateTextBoxesForBots()
    {
        foreach(var player in Players)
        {
            player.IsTextBoxEnabled = Players.Count < 2;
        }
    }

    private void CheckPlayersCount()
    {
        AddPlayerButton.IsEnabled = Players.Count < 2;
        AddBotButton.IsEnabled = Players.Count < 2;
    }   
}