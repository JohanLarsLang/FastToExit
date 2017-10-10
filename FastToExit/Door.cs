using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Door : Square
    {

        public Door()
        {
            Sign = SquareType.Door;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You passed a door!";
            else
                message = "You need a key to pass the door!";

            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}
