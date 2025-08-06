using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.Iterators
{
    internal class NullIterator: Iterator
    {
#pragma warning disable CS8603 // Possible null reference return.
        public object next() { return null; }
        public bool hasNext() { return false; }
    }
}
