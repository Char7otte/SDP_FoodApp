using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
{
    public class CancelOrder : OrderCommand
    {
        private Order order;

        public CancelOrder(Order order)
        {
            this.order = order;
        }

        public void Execute()
        {
            order.Cancel();
        }

        public void Undo()
        {
            order.Place();
        }
    }
}