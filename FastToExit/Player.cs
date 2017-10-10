using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Player
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public static bool Sword { get; set; }
        public static bool DoorKey { get; set; }
        public static int Score { get; set; }
        public static int Steps { get; set; }


        public Player(int xpos, int ypos, bool sword, bool doorKey, int score, int steps)
        {
            Xpos = xpos;
            Ypos = ypos;
            Sword = sword;
            DoorKey = doorKey;
            Score = score;
            Steps = steps;

        }

        public string Print()
        {
            return "" + '@';
        }
    }
}
