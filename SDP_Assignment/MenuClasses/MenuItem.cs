using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.IteratorClasses;

namespace SDP_Assignment.MenuClasses
{
    public class MenuItem : MenuComponent
    {
        private string name;
        private string description;
        private bool vegetarian;
        private double price;

        public override string Name { get { return name; } }
        public override string Description { get { return description; } }
        public override bool Vegetarian { get { return vegetarian; } }
        public override double Price { get { return price; } }

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            this.name = name;
            this.description = description;
            this.vegetarian = vegetarian;
            this.price = price;
        }

        public override void print()
        {
            Console.Write($"{name}");
            if (vegetarian)
            {
                Console.Write("(veg.)");
            }
            Console.WriteLine($": ${price:N2}");
            Console.WriteLine($" -- {description}");
        }

        public override Iterator createIterator()
        {
            return new NullIterator();
        }
    }
}
