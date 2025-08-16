
using System.Xml.Linq;

namespace ConsoleApp1
{
    class Customer : User //missing - thing to make order
    {
        public Customer(string password, string name) : base(password, name) {}


        public void subscribe(Restaurant r) { r.SubCustomer(this); }
        public void unsubscribe(Restaurant r) { r.UnsubCustomer(this); }

        public void Update(string offer)
        {
            Console.WriteLine($"{Name} got notified: {offer}");
        }


    }
}