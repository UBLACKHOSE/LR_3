using System;
using System.Collections.Generic;
using System.Text;

namespace LR3_3
{
    internal interface Person
    {
        public Location Moving(Location location);
        public string GetInfo();
    }
}
