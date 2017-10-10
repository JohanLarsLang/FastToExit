using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Room : Square
    {

        public Room()
        {
            Sign = SquareType.Empty;
        }

        public static new string Message(bool b)
        {
            return "";
        }

        public new bool Visable()
        {
            return true;
        }
    }
}
