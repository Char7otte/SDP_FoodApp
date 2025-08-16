using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.PaymentClasses
{
    public class PayPal : Payment
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid ${amount} using PayPal.");
        }
    }
}