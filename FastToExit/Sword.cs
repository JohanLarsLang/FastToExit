using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Sword : Square
    {
        public Sword()
        {
            Sign = SquareType.Sword;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You pick up a sword!";
           
            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}
