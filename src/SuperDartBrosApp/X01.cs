using Avalonia;
using SuperDartBrosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;
using Avalonia.Controls;

namespace SuperDartBrosApp
{
    public class X01 : IGameMode
    {
        private int startPoints;
        private IEnumerable<Player> players;

        public Check_Outs CheckOut { get; set; }


        public X01(int startPoints, Check_Outs check_Outs)
        {
            this.startPoints = startPoints;
            CheckOut = check_Outs;
        }

        public void InitializeMode(IEnumerable<Player> players)
        {
            this.players = players;
            foreach(var player in players)
            {
                player.Score = startPoints;
            }
        }

        public void PlayRound(Player player)
        {
            List<int> pointsInNum = new List<int>();
            for (int i = 0; i < player.Points.Count; i++)
            {
                pointsInNum.Add(int.Parse(player.Points[i].Trim(['B', 'D', 'S'])));
            }

            if (CheckOut is Check_Outs.StraightOut)
            {
                if (player.Score - pointsInNum.Sum() >= 0)
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (CheckOut is Check_Outs.DoubleOut)
            {
                if (player.Score - pointsInNum.Sum() == 0 && player.Points.Last().Contains("D"))
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (CheckOut is Check_Outs.TripleOut)
            {
                if (player.Score - pointsInNum.Sum() == 0 && player.Points.Last().Contains("T"))
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (CheckOut is Check_Outs.MasterOut)
            {
                if (player.Score - pointsInNum.Sum() == 0 && player.Points.Last().Contains("B"))
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
        }

        public void GameFinished()
        {
            throw new NotImplementedException();
        }

        public void IntializeGameMode(IEnumerable<Player> players)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }

        public void ProcessThrow(Player player, string points)
        {
            throw new NotImplementedException();

       
        }

    }
}
