using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class SuperKey : Square
    {

        public SuperKey()
        {
            Sign = SquareType.SuperKey;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "You pick up a super key!";

            return message;
        }

        public new bool Visible()
        {
            return true;
        }

    }
}
