using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SuperDartBrosApp.Models
{
    public class Player
    {
        private List<int> pointsInNum = new List<int>();

        public string Name { get; set; }
        public int Score { get; set; }

        public List<string> Points = new List<string>();

        public List<int> PointsInNum
        {
            get
            {
                pointsInNum.Clear();
                for (int i = 0; i < Points.Count; i++)
                {
                    if (Points[i].Contains("S"))
                    {
                        pointsInNum.Add(int.Parse(Points[i].Trim('S')));
                    }
                    else if (Points[i].Contains("D"))
                    {
                        pointsInNum.Add(int.Parse(Points[i].Trim('D')) * 2);
                    }
                    else if (Points[i].Contains("T"))
                    {
                        pointsInNum.Add(int.Parse(Points[i].Trim('T')) * 3);
                    }
                    else if (Points[i].Contains("B"))
                    {
                        pointsInNum.Add(int.Parse(Points[i].Trim('B')));
                    }
                }
                return pointsInNum;
            }
        }

        public bool IsBot { get; set; }

        public bool IsTextBoxEnabled { get; set; } = true;

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }   

        public static int PointToScore(string point)
        {
            if (point.Contains("S"))
            {
                return int.Parse(point.Trim('S'));
            }
            else if (point.Contains("D"))
            {
                return int.Parse(point.Trim('D')) * 2;
            }
            else if (point.Contains("T"))
            {
                return int.Parse(point.Trim('T')) * 3;
            }
            else if (point.Contains("B"))
            {
                return int.Parse(point.Trim('B'));
            }
            return 0;
        }

        public void Add(string points)
        {
            Points.Add(points);
        }

        public void ResetPoints()
        {
            Points.Clear();
            pointsInNum.Clear();
        }

    }
}
