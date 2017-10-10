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

        public new static string Message(bool b)
        {
            return "";
        }

        public new bool Visible()
        {
            return true;
        }
    }
}
