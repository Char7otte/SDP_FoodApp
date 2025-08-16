using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assignment.CommandClasses
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
            order.getFood();
            Console.WriteLine($"Your order is ${order.calculateCost()}");
            Console.WriteLine("Confirm your order: (Y/N)");
            var input = Console.ReadLine()?.ToUpper(); //c# is too strict dawg why am I getting Console might be null 
            if (input == "N")
            {
                Console.WriteLine("You have cancelled your order.");
                order.cancelOrder();
                return;
            }
            else if (input == "Y")
            {
                order.confirmOrder();
                return;
            }

            Console.WriteLine("Please enter a valid option.");
            Execute();
        }

        public void Undo()
        {
            order.cancelOrder();
        }

        public void cancel()
        {
            order.cancelOrder();
        }
    }
}