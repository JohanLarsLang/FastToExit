﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class DoorKey : Square
    {

        public DoorKey()
        {
            Sign = SquareType.DoorKey;
        }

        public new static string Message(bool b)
        {
            string message = "";

            if (b == true)
                 message = "You pick up a key!";

            return message;
        }

        public new bool Visible()
        {
            return true;
        }
    }
}
