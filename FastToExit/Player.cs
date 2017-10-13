using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Player : Square
    {
        public int Xpos { get; set; }
        public int Ypos { get; set; }

        public static bool Sword { get; set; }
        public static bool Rope { get; set; }
        public static bool Cage { get; set; }
        public static bool DoorKey { get; set; }
        public static bool SuperKey { get; set; }
        public static bool Exit { get; set; }
        public static int Score { get; set; }
        public static int Steps { get; set; }


        public Player(int xpos, int ypos, bool sword, bool doorKey, bool superKey, bool exit, int score, int steps)
        {
            Xpos = xpos;
            Ypos = ypos;
            Sword = sword;
            DoorKey = doorKey;
            SuperKey = superKey;
            Exit = exit;
            Score = score;
            Steps = steps;

        }

        public Player(int xpos, int ypos)
        {
            Sign = SquareType.Player;

            Xpos = xpos;
            Ypos = ypos;
        }
    }
}
