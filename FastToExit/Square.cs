using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public abstract class Square : Isignable
    {
        public virtual char Print()
        {
            return ' ';

        }

        public bool visable()
        {
            return true;
        }

    }
}
