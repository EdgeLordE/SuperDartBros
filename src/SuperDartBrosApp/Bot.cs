using System;
using System.Collections.Generic;
using System.Linq;
using SuperDartBrosApp.Models;

namespace SuperDartBrosApp
{
    public class Bot : Player
    {
        private static Random random = new Random();
        private string checkOutRule;

        public Bot(string name, int score, string checkOutRule) : base(name, score)
        {
            IsBot = true;
            this.checkOutRule = checkOutRule;
        }   

        public void PlayTurn()
        {
            if (Score <= 0) return;

            List<string> possibleThrows = GeneratePossibleThrows();
            SimulateThrows(possibleThrows);
        }

        private List<string> GeneratePossibleThrows()
        {
            List<string> throws = new List<string>();
            
            if (checkOutRule == "Straight Out")
            {
                for (int i = 1; i <= 20; i++)
                {
                    throws.Add($"S{i}");
                    throws.Add($"D{i}");
                    throws.Add($"T{i}");
                }
                throws.Add("B25");
                throws.Add("B50");
            }
            else if (checkOutRule == "Double Out")
            {
                for (int i = 1; i <= 20; i++)
                {
                    throws.Add($"D{i}");
                }
                throws.Add("B50");
            }
            else if (checkOutRule == "Triple Out")
            {
                for (int i = 1; i <= 20; i++)
                {
                    throws.Add($"T{i}");
                }
            }
            else if (checkOutRule == "Master Out")
            {
                for (int i = 1; i <= 20; i++)
                {
                    throws.Add($"D{i}");
                    throws.Add($"T{i}");
                }
                throws.Add("B50");
            }
            return throws;
        }

        private void SimulateThrows(List<string> possibleThrows)
        {
            int dartsThrown = 0;
            while (dartsThrown < 3 && Score > 0)
            {
                string chosenThrow = possibleThrows[random.Next(possibleThrows.Count)];
                int pointsScored = Player.PointToScore(chosenThrow);
                
                if (Score - pointsScored >= 0 && IsValidCheckout(chosenThrow))
                {
                    Score -= pointsScored;
                    Points.Add(chosenThrow);
                }
                dartsThrown++;
            }
        }

        private bool IsValidCheckout(string lastThrow)
        {
            if (Score > 0) return true;
            if (checkOutRule == "Straight Out") return true;
            if (checkOutRule == "Double Out" && lastThrow.StartsWith("D")) return true;
            if (checkOutRule == "Triple Out" && lastThrow.StartsWith("T")) return true;
            if (checkOutRule == "Master Out" && (lastThrow.StartsWith("D") || lastThrow.StartsWith("T") || lastThrow == "B50")) return true;
            return false;
        }
    }
}
