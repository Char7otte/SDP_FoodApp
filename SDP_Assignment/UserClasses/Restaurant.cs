using System;

namespace ConsoleApp1
{
    class Restaurant : User//menu stuff
    {
        public Restaurant(string password, string name) : base(password, name) { }

        private List<Customer> subscribers = new List<Customer>();

        public void SubCustomer(Customer c) { subscribers.Add(c); }
        public void UnsubCustomer(Customer c) { subscribers.Remove(c); }

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

