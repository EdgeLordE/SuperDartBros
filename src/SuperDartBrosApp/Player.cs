using System.Collections.Generic;

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

        public void AddPoint(int points)
        {
            Points.Add(point);
        }

        public void ResetPoints()
        {
            Points.Clear();
        }

        public void Multiplier(int multiplier)
        {

            if(multiplier == 2)
            {
                Points.Add("D");
            }
            else if(multiplier == 3)
            {
                Points.Add("T");
            }

        }
    }
}