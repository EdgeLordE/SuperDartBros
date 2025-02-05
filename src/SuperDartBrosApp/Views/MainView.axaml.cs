﻿using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SuperDartBrosApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperDartBrosApp.Views
{
    public partial class MainView : UserControl
    {
        public string CurrentPlayer { get; private set; }

        private List<Player> players;
        private int currentPlayerIndex = 0;
        private int throwCount = 0;

        private Dictionary<Player, List<int>> playerThrows = new Dictionary<Player, List<int>>();

        public MainView(GameSettings gameSettings)
        {
            InitializeComponent();  
            players = gameSettings.Players.ToList();

            foreach(var player in players)
            {
                playerThrows[player] = new List<int>();
            }

            CurrentPlayer = players[currentPlayerIndex].Name;
            UpdateUI();
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void UpdateUI()
        {
            var currentPlayerLabel = this.FindControl<Label>("CurrentPlayerLabel");
            currentPlayerLabel.Content = CurrentPlayer;

            var scoreLabel = this.FindControl<Label>("ScoreLabel");
            var currentPlayerObj = players[currentPlayerIndex];
            scoreLabel.Content = currentPlayerObj.Score.ToString("D2");

            var currentThrows = playerThrows[currentPlayerObj];
            var throw1Label = this.FindControl<Label>("Throw1Label");
            var throw2Label = this.FindControl<Label>("Throw2Label");
            var throw3Label = this.FindControl<Label>("Throw3Label");

            throw1Label.Content = currentThrows.Count > 0 ? currentThrows[0].ToString() : "";
            throw2Label.Content = currentThrows.Count > 1 ? currentThrows[1].ToString() : "";
            throw3Label.Content = currentThrows.Count > 2 ? currentThrows[2].ToString() : "";

            var scoreBoardList = this.FindControl<ListBox>("ScoreBoardList");
            var scoreItems = players.Select(p => $"{p.Name}: {p.Score}").ToList();
            scoreBoardList.ItemsSource = scoreItems;  
        }

        public void RegisterThrow(int points)
        {
            var currentPlayerObj = players[currentPlayerIndex];

            playerThrows[currentPlayerObj].Add(points);
            currentPlayerObj.Score -= points;

            throwCount++;
            UpdateUI();

            if(throwCount >= 3)
            {
                playerThrows[currentPlayerObj].Clear();
                throwCount = 0;
                SwitchPlayer();
            }
        }

        public void SwitchPlayer()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            CurrentPlayer = players[currentPlayerIndex].Name;
            UpdateUI();
        }




        public void OnThrowCompleted()
        {
            RegisterThrow(0); 
        }

        private void StandardClick(int value)
        {
            RegisterThrow(value);
        }

        private void DoubleClick(int value)
        {
            RegisterThrow(value * 2);
        }

        private void TripleClick(int value)
        {
            RegisterThrow(value * 3);
        }
    



#region buttons

        private void Bull25_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Logik für Bull25
        }

        private void BullE50_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Logik für BullE50
        }

        private void D1_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(1);
        }

        private void D2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(2);
        }

        private void D3_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(3);
        }

        private void D4_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(4);
        }

        private void D5_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(5);
        }

        private void D6_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(6);
        }

        private void D7_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(7);
        }

        private void D8_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(8);
        }

        private void D9_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(9);
        }

        private void D10_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(10);
        }

        private void D11_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(11);
        }

        private void D12_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(12);
        }

        private void D13_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(13);
        }

        private void D14_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(14);
        }

        private void D15_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(15);
        }

        private void D16_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(16);
        }

        private void D17_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(17);
        }

        private void D18_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(18);
        }

        private void D19_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(19);
        }

        private void D20_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            DoubleClick(20);
        }


        // Click-Events für Standard-Felder

        private void S1_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(1);
        }

        private void S2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(2);
        }

        private void S3_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(3);
        }

        private void S4_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(4);
        }

        private void S5_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(5);
        }

        private void S6_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(6);
        }

        private void S7_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(7);
        }

        private void S8_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(8);
        }

        private void S9_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(9);
        }

        private void S10_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(10);
        }

        private void S11_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(11);
        }

        private void S12_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(12);
        }

        private void S13_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(13);
        }

        private void S14_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(14);
        }

        private void S15_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(15);
        }

        private void S16_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(16);
        }

        private void S17_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(17);
        }

        private void S18_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(18);
        }

        private void S19_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(19);
        }

        private void S20_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            StandardClick(20);
        }

       
        }
     #endregion

}