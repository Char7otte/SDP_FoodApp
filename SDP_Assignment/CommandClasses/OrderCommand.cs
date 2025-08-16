using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
{
    public interface OrderCommand
    {
        void Execute();
        void Undo();
        void cancel();
    }
}
