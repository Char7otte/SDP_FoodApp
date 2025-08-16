using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP_Assg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Choose payment method (Strategy)
            Payment paymentMethod = new CreditCard(); // Could switch to PayPal, Cash etc

            Order myOrder = new Order("Burger Combo Meal", paymentMethod)
            {
                Amount = 15.00
            };

            // Create commands
            OrderCommand placeCommand = new PlaceOrder(myOrder);
            OrderCommand cancelCommand = new CancelOrder(myOrder);

            // Controller (Invoker)
            OrderController controller = new OrderController();

            // Place order
            controller.SetCommand(placeCommand);
            controller.SubmitOrder();

            // Undo order
            controller.UndoOrder();

            // Cancel order directly
            controller.SetCommand(cancelCommand);
            controller.SubmitOrder();

        }
    }
}