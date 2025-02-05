using SuperDartBrosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

       //
        }

    }
}
