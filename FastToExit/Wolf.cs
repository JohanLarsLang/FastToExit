using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Wolf : Square
    {
        public Wolf()
        {
            Sign = SquareType.Wolf;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You catched the wolf!";
            else
                message = "You need a a rope and a cage to catch the wolf!";

            return message;
        }

        public new bool Visible()
        {
            return false;
        }
    }
}
