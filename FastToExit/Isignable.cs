using System;
using System.Collections.Generic;
using System.Text;

namespace FastToExit
{
    public interface ISignable
    {
        bool Visible();
        string Message(bool b);
    }
}
