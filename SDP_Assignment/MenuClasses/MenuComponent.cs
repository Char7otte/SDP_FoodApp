using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.IteratorClasses;

namespace SDP_Assignment.MenuClasses
{
    internal abstract class MenuComponent
    {
        public virtual void add(MenuComponent mc)
        {
            throw new NotSupportedException();
        }
        public virtual void remove(MenuComponent mc)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent getChild(int index)
        {
            throw new NotSupportedException();
        }
        public virtual void print()
        {
            throw new NotSupportedException();
        }
        public virtual string Name
        {
            get { throw new NotSupportedException(); }
        }
        public virtual string Description
        {
            get { throw new NotSupportedException(); }
        }
        public virtual double Price
        {
            get { throw new NotSupportedException(); }
        }
        public virtual bool Vegetarian
        {
            get { throw new NotSupportedException(); }
        }

        public virtual Iterator createIterator()
        {
            throw new NotSupportedException();
        }
    }
}
