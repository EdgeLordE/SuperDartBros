using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDartBrosApp.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public List<string> Points = new List<string>();

        public bool IsBot { get; set; }

        public bool IsTextBoxEnabled { get; set; } = true;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }   

        public void SubtractScore(int points)
        {
            if (Score - points >= 0)
            {
                Score -= points;
            }
        }

     

        public void ResetPoints()
        {
            Points.Clear();
        }

    }
}
