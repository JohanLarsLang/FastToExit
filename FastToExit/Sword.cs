using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Sword : Square
    {

        public override char Print()
        {
            return 's';
        }

        public new bool visable()
        {
            return true;
        }
    }
}
