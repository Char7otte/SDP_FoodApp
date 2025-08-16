using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    public interface OrderCommand
    {
        void Execute();
        void Undo();
    }
}
