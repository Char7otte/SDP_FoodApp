using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.Iterators;

namespace SDP_Assignment.Menus
{
    internal class Waitress
    {
        private MenuComponent allMenus;

        public Waitress(MenuComponent mc)
        {
            allMenus = mc;
        }

        public void addMenu(MenuComponent mc)
        {
            allMenus.add(mc);
        }

        public void printMenu()
        {
            allMenus.print();
        }

        public void printVegetarianMenu()
        {
            Iterator iter = allMenus.createIterator();
            Console.WriteLine("VEGETARIAN MENU");
            while (iter.hasNext())
            {
                MenuComponent mc = (MenuComponent)iter.next();
                try
                {
                    if (mc.Vegetarian == true)
                        mc.print();
                }
                catch (NotSupportedException) { }
            }
        }
    }
}
