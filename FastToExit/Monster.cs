using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Monster : Square
    {

        public override char Print()
        {
            return 'M';
        }

        public new bool visable()
        {
            return false;
        }
    }
}
