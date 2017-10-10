using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public abstract class Square : ISignable
    {
        public SquareType Sign { get; set; }

        public char Print()
        {
            return (char)Sign;

        }

        public string Message(bool b)
        {
            return "";
        }
     

        public bool Visible()
        {
            return true;
        }

    }
}
