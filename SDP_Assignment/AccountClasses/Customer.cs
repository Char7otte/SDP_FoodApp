using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.MenuClasses;

namespace SDP_Assignment.AccountClasses
{
    internal class Customer: Account
    {
        public Customer() {}

        public Customer(string username, string password): base(username, password)
        {
            Console.WriteLine($"Customer {username} has been created");
        }
        
        public void subscribe(DinerMenu r) { r.SubCustomer(this); }
        public void unsubscribe(DinerMenu r) { r.UnsubCustomer(this); }

        public void Update(string offer)
        {
            Console.WriteLine($"{Username} got notified: {offer}");
        }
    }
}
