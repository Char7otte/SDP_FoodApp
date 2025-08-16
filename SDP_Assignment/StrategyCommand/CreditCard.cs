using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    public class CreditCard : Payment
    {
        public void Pay(Double amount)
        {
            Console.WriteLine($"Paid ${amount} using Credit Card.");
        }
    }
}

