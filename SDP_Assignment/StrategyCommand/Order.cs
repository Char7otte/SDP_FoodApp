using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    public class Order
    {
        public string Item { get; set; }
        public double Amount { get; set; }
        private Payment paymentMethod;

        public Order(string item, Payment paymentMethod)
        {
            Item = item;
            this.paymentMethod = paymentMethod;
        }

        public void SetPaymentMethod(Payment payment)
        {
            paymentMethod = payment;
        }

        public void Place()
        {
            paymentMethod.Pay(Amount);
            Console.WriteLine("Order placed successfully.");
        }

        public void Cancel()
        {
            Console.WriteLine($"Order is cancelled.");
        }
    }
}