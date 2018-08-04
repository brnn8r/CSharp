using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullGuardTest
{
    [Equals]
    [ToString]
    public class MyInt
    {
        public MyInt(int i, string description)
        {
            I = i;
            Description = description;
        }

        public int I { get; }
        public string Description { get; }
    }
}
