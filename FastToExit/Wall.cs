﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public class Wall : Square
    {

        public override char Print()
        {
            return '#';
        }

        public new bool visable()
        {
            return true;
        }
    }
}

