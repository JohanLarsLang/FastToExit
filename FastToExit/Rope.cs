using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Rope : Square
    {

        public Rope()
        {
            Sign = SquareType.Rope;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You pick a rope!";
         
            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}

