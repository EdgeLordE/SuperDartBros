using Avalonia.Controls;
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
        private List<string> settings;
        private int currentPlayerIndex = 0;
        private int throwCount = 0;

        private Dictionary<Player, List<int>> playerThrows = new Dictionary<Player, List<int>>();

        public MainView(GameSettings gameSettings)
        {
            InitializeComponent();  
            players = gameSettings.Players.ToList();
            settings = gameSettings.settingsList.ToList();

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

            if(players.Any(p => p.Score == 0))
            {
                WinnerUserControl winnerUserControl = new WinnerUserControl();
                winnerUserControl.LblWinner.Content = $"{players[currentPlayerIndex].Name} hat gewonnen!";
                Content = winnerUserControl;
            }
        }

        public void RegisterThrow(string yarrak, int point)
        {
            Player currentPlayerObj = players[currentPlayerIndex];

            if (yarrak == "" && point == 0 || throwCount >= 3)
            {
                playerThrows[currentPlayerObj].Add(Player.PointToScore($"{yarrak}{point}"));
            }
            else
            {
                playerThrows[currentPlayerObj].Add(Player.PointToScore($"{yarrak}{point}"));
                currentPlayerObj.Add($"{yarrak}{point}");
            }

            throwCount++;
            UpdateUI();
        }

        public void SwitchPlayer()
        {
            
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            CurrentPlayer = players[currentPlayerIndex].Name;
            UpdateUI();
        }

        private void OutClick()
        {
            RegisterThrow("", 0); 
        }

        private void StandardClick(int value)
        {
            RegisterThrow("S", value);
        }

        private void DoubleClick(int value)
        {
            RegisterThrow("D", value);
        }

        private void TripleClick(int value)
        {
            RegisterThrow("T", value);
        }

        private void BullClick(int value)
        {
            RegisterThrow("B", value);
        }
    
        private void BtnReset_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            playerThrows[players[currentPlayerIndex]].Clear();
            throwCount = 0;
            UpdateUI();
            players[currentPlayerIndex].ResetPoints();

        }

        private void BtnConfirm_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (throwCount >= 3)
            {
                Player currentPlayerObj = players[currentPlayerIndex];
                playerThrows[currentPlayerObj].Clear();
                throwCount = 0;
                SwitchPlayer();
                if (settings[1] == "X01")
                {
                    X01.PlayRound(currentPlayerObj, settings[3]);
                }
                currentPlayerObj.ResetPoints();
            }
            UpdateUI();
        }


        #region Dartboard-Buttons
        private void BtnOut_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            OutClick();
        }

        private void Bull25_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BullClick(25);
        }

        private void BullE50_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            BullClick(50);
        }

        private void T1_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(1);
        }

        private void T2_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(2);
        }

        private void T3_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(3);
        }

        private void T4_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(4);
        }

        private void T5_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(5);
        }

        private void T6_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(6);
        }

        private void T7_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(7);
        }

        private void T8_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(8);
        }

        private void T9_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(9);
        }

        private void T10_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(10);
        }

        private void T11_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(11);
        }

        private void T12_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(12);
        }

        private void T13_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(13);
        }

        private void T14_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(14);
        }

        private void T15_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(15);
        }

        private void T16_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(16);
        }

        private void T17_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(17);
        }

        private void T18_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(18);
        }

        private void T19_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(19);
        }

        private void T20_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            TripleClick(20);
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

        // Double-Click-Events

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


    }
    #endregion

}