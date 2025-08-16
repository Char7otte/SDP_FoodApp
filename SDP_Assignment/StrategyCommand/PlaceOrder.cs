using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    public class PlaceOrder : OrderCommand
    {
        private Order order;

        public PlaceOrder(Order order)
        {
            this.order = order;
        }

        public void Execute()
        {
            order.Place();
        }

        public void Undo()
        {
            order.Cancel();
        }
    }
}