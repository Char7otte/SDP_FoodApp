using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
{
    public class PreparingDone : OrderCommand
    {
        private Order order;

        public PreparingDone(Order order)
        {
            this.order = order;
        }

        public void Execute()
        {
           Console.WriteLine("...");
        Console.ReadLine();

        order.foodComplete();
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