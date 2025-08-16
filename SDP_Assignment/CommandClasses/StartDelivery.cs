using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
{
    public class StartDelivery : OrderCommand
    {
        private Order order;

        public StartDelivery(Order order)
        {
            this.order = order;
        }

        public void Execute()
        {
            Console.WriteLine("Delivery has started.");
        Console.ReadLine();

        order.deliver();
        }

        public void Undo()
        {
            return;
        }

        public void cancel()
        {
            return;
        }
    }
}