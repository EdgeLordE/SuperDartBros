using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperDartBrosApp
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<int> Points { get; set; }

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

        public void AddPoint(int point)
        {
            Points.Add(point);
        }

        public void ResetPoints()
        {
            Points.Clear();
        }
    }
}
