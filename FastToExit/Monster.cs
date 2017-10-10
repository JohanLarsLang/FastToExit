using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Monster : Square
    {
        public Monster()
        {
            Sign = SquareType.Monster;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You killed the monster!";
            else
                message = "You need a sword to kill the monster!";

            return message;
        }

        public new bool Visible()
        {
            return false;
        }
    }
}
