using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Cage : Square
    {

        public Cage()
        {
            Sign = SquareType.Cage;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You pick a cage!";

            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}
