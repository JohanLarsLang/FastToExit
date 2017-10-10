using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Wall : Square
    {
        public Wall()
        {
            Sign = SquareType.Wall;
        }

        public new static string Message(bool b)
        {
            string message = "";

            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}

