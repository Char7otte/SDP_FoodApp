using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    public class Cash : Payment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Payment of ${amount} will be collected on delivery.");
        }
    }
}