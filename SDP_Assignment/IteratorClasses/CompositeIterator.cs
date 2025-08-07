using SDP_Assignment.MenuClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.IteratorClasses
{
    internal class CompositeIterator: Iterator
    {
        Stack<Iterator> stack = new Stack<Iterator>();
        public CompositeIterator(Iterator iter)
        {
            stack.Push(iter);
        }

        public bool hasNext()
        {
            if (stack.Count == 0)
                return false;
            else
            {
                Iterator iter = stack.Peek();
                if (!iter.hasNext())
                {
                    stack.Pop();
                    return hasNext();
                }
                else
                    return true;
            }
        }

        public object next()
        {
            Iterator iter = stack.Peek();
            MenuComponent component =
            (MenuComponent)iter.next();
            if (component is DinerMenu)
                stack.Push(component.createIterator());
            return component;
        }
    }
}
