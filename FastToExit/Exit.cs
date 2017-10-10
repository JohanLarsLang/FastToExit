using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Exit : Square
    {
        public Exit()
        {
            Sign = SquareType.Exit;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                message = "Congratulations! You succeeded to go to the Exit!";
            else
                message = "You need a key to go to the Exit!";

            return message;
        }

    }
}
