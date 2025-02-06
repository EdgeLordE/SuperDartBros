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


        public X01(int startPoints)
        {
            this.startPoints = startPoints;
        }

        public void InitializeMode(IEnumerable<Player> players)
        {
            this.players = players;
            foreach(var player in players)
            {
                player.Score = startPoints;
            }
        }

        public static void PlayRound(Player player, string check_out)
        {
            List<int> pointsInNum = player.PointsInNum;

            if (check_out == "Straight Out")
            {
                if (player.Score - pointsInNum.Sum() >= 0)
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (check_out == "Double Out")
            {
                if (player.Score - pointsInNum.Sum() == 0 && player.Points.Last().Contains("D"))
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (check_out == "Triple Out")
            {
                if (player.Score - pointsInNum.Sum() == 0 && player.Points.Last().Contains("T"))
                {
                    player.Score -= pointsInNum.Sum();
                    player.ResetPoints();
                }
            }
            else if (check_out == "Master Out")
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
