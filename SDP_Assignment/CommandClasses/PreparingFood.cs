using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.PaymentClasses;

namespace SDP_Assignment.CommandClasses {
        public class PreparingFood: OrderCommand {
                private Order order;

                public PreparingFood(Order order) {
                        this.order = order;
                }

        public void Execute()
        {
            Console.WriteLine("Restaurant is now preparing your food...");
            Console.ReadLine();
            order.startPreparation();
        }

        public void Undo() {
                order.cancelOrder();
        }

        public void cancel() {
                order.cancelOrder();
        }
}
}