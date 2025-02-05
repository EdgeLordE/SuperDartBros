using SuperDartBrosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDartBrosApp
{
    public interface IGameMode
    {
        void IntializeGameMode(IEnumerable<Player> players);
        void ProcessThrow(Player player, string points);
        bool IsGameOver();
        //
        
        void GameFinished();
    }
}