using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class PlayerScore
    {
        private string playerName;
        private int playerScore;

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        public int PlayerScorePoints
        {
            get { return playerScore; }
            set { playerScore = value; }
        }

        public PlayerScore() { }

        public PlayerScore(string name, int score)
        {
            this.playerName = name;
            this.playerScore = score;
        }
    }
}
