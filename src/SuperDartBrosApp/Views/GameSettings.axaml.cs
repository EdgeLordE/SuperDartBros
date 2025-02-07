using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Markup.Xaml;
using SuperDartBrosApp.Models;
using SuperDartBrosApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SuperDartBrosApp
{
    public partial class GameSettings : UserControl
    {
        public ObservableCollection<Player> Players { get; } = new ObservableCollection<Player>();
        public List<string> settingsList = new List<string>();

        public GameSettings(IEnumerable<Player> players)
        {
            InitializeComponent();


            foreach (var player in players)
            {
                Players.Add(player);
            }

            DataContext = this;
            CheckPlayersCount();
        }
        public void GetRandomPlayer()
        {
            var random = new Random();
            var randomOrder = random.Next(0, 2);
            if(randomOrder == 1)
            {
                var temp = Players[0];
                Players[0] = Players[1];
                Players[1] = temp;
            }
        }

        private void BtnStart_Click(object? sender, RoutedEventArgs e)
        {
            bool randomOrder = (this.FindControl<CheckBox>("RandomOrderCheckBox")?.IsChecked) ?? false;

            var gameModeComboBox = this.FindControl<ComboBox>("GameModeComboBox");
            string gameMode = (gameModeComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nicht ausgewählt";

            var startPointsComboBox = this.FindControl<ComboBox>("StartPointsComboBox");
            string startPoints = (startPointsComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nicht ausgewählt";

            var checkOutComboBox = this.FindControl<ComboBox>("CheckOutComboBox");
            string checkOut = (checkOutComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nicht ausgewählt";

            //var setsComboBox = this.FindControl<ComboBox>("SetsComboBox");
            //string sets = (setsComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nicht ausgewählt";

            //var legsComboBox = this.FindControl<ComboBox>("LegsComboBox");
            //string legs = (legsComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nicht ausgewählt";

            settingsList = new List<string>
            {
                $"Zufällige Reihenfolge: {randomOrder}",
                gameMode,
                startPoints,
                checkOut,
                "Spieler:"
            };

                //$"Sets: {sets}",
                //$"Legs: {legs}",

            foreach(var player in Players)
            {
                settingsList.Add($" - {player.Name}");
            }

            var settingsWindow = new Window
            {
                Title = "Ausgewählte Game Settings",
                Width = 300,
                Height = 400,
                Content = new ScrollViewer
                {
                    Content = new TextBlock
                    {
                        Text = string.Join(Environment.NewLine, settingsList),
                        Foreground = Brushes.White,
                        Background = Brushes.Black,
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap,
                        Margin = new Thickness(10)
                    }
                }
            };
            SetPlayerScoreToStartPoints();

            if(RandomOrderCheckBox.IsChecked == true)
            {
                GetRandomPlayer();
            }   
            var mainview = new MainView(this);
            Content = mainview;
            //settingsWindow.Show();
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
                var newPlayer = new Player("Neuer Spieler", 0);
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
                var bot = new Player(GetRandomBotName(), 0);
                Players.Add(bot);

                UpdateTextBoxesForBots();

                if(Players.Count == 2)
                {
                    //AddBotButton.IsEnabled = false;
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
            //AddBotButton.IsEnabled = Players.Count < 2;
        }
        private void SetPlayerScoreToStartPoints()
        {
            var startPointsComboBox = this.FindControl<ComboBox>("StartPointsComboBox");
            int startPoints = int.TryParse((startPointsComboBox?.SelectedItem as ComboBoxItem)?.Content?.ToString(), out int points) ? points : 0;

            foreach(var player in Players)
            {
                if(player.Score == 0)
                {
                    player.Score = startPoints;
                }
            }
        }
    }
}
