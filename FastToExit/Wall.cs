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

        public static new string Message(bool b)
        {
            string message = "";

            return message;
        }

        public new bool Visable()
        {
            return true;
        }
    }
}

