using SDP_Assignment.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.Iterators
{
    internal class DinerMenuIterator: Iterator
    {
        private List<MenuComponent> menu;
        private int position = 0;

        public DinerMenuIterator(List<MenuComponent> menu)
        {
            this.menu = menu;
        }

        public bool hasNext()
        {
            return position < menu.Count;
        }

        public object next()
        {
            return menu[position++];
        }

    }
}
