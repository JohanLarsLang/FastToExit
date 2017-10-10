using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Door : Square
    {

        public override char Print()
        {
            return 'D';
        }

        public new bool visable()
        {
            return true;
        }
    }
}
