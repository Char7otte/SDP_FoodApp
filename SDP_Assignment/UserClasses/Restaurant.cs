using System;

namespace ConsoleApp1
{
    class Restaurant : User//menu stuff
    {
        public Restaurant(string password, string name) : base(password, name) { }

        private List<Customer> subscribers = new List<Customer>();

        public void SubCustomer(Customer c)
        {
            if (!subscribers.Contains(c))
            {
                subscribers.Add(c);
                Console.WriteLine($"{c.Name} has been subscribed to {this.Name}");
            }
            else
            {
                Console.WriteLine($"{c.Name} is already subscribed to {this.Name}.");
            }
        }
        public void UnsubCustomer(Customer c) 
        {
            if (subscribers.Contains(c))
            {
                subscribers.Remove(c);
                Console.WriteLine($"{c.Name} has been unsubscribed from {this.Name}");
            }
            else
            {
                Console.WriteLine($"{c.Name} is not subscribed to {this.Name}.");
            }
        }

        public void AddNewOffer(string offer)
        {
            Console.WriteLine($"{Name} posted: {offer}");
            NotifySubscribers(offer);
        }

        private void NotifySubscribers(string offer)
        {
            foreach (Customer subscription in subscribers)
            {
                subscription.Update(offer);
            }

        }
    }
}

