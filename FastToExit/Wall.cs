using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Wall : Square
    {

        public char PrintWall()
        {
            return '#';
        }

        public new bool visable()
        {
            return true;
        }
    }
}

