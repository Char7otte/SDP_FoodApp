using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.IteratorClasses;
using SDP_Assignment.AccountClasses;

namespace SDP_Assignment.MenuClasses
{
    internal class DinerMenu : MenuComponent
    {
        private List<MenuComponent> components;

        public override string Name { get; }
        private Iterator? iter = null;

        public DinerMenu(string name)
        {
            Name = name;
            components = new();

            Console.WriteLine($"{name} has been created.");
        }

        public void addItem(string name, string desc, bool veg, double price)
        {
            MenuItem newItem = new(name, desc, veg, price);
            components.Add(newItem);
        }

        public override Iterator createIterator()
        {
            if (iter == null)
            {
                iter = new CompositeIterator(new DinerMenuIterator(components));
            }
            return iter;
        }

        public override void add(MenuComponent mc)
        {
            components.Add(mc);
            // Console.WriteLine($"{mc.Name} has been added to {Name}");
        }

        public override void remove(MenuComponent mc)
        {
            components.Remove(mc);
        }

        public override MenuComponent getChild(int index)
        {
            return components[index];
        }

        public override void print()
        {
            Console.WriteLine(Name.ToUpper());
            this.iter = createIterator();
            while (iter.hasNext())
            {
                MenuComponent menuComponent = (MenuComponent)iter.next();
                menuComponent.print();
            }
            this.iter = null;
            Console.WriteLine();
        }

        private List<Customer> subscribers = new List<Customer>();

        public void SubCustomer(Customer c)
        {
            if (!subscribers.Contains(c))
            {
                subscribers.Add(c);
                Console.WriteLine($"{c.Username} has been subscribed to {this.Name}");
            }
            else
            {
                Console.WriteLine($"{c.Username} is already subscribed to {this.Name}.");
            }
        }
        public void UnsubCustomer(Customer c)
        {
            if (subscribers.Contains(c))
            {
                subscribers.Remove(c);
                Console.WriteLine($"{c.Username} has been unsubscribed from {this.Name}");
            }
            else
            {
                Console.WriteLine($"{c.Username} is not subscribed to {this.Name}.");
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