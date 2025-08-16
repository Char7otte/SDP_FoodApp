using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.PaymentClasses;

namespace SDP_Assignment.CommandClasses {
  public class PayForOrder: OrderCommand {
    private Order order;

    public PayForOrder(Order order) {
      this.order = order;
    }

    public void Execute() {
      while (true) {
        Console.WriteLine("Select payment method: ");
        Console.WriteLine("1. Cash");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. PayPal");
        Console.WriteLine("0. Exit");
        var input = Console.ReadLine();

        if (input == "0") {
          order.cancelOrder();
          return;
        }

        switch (input) {
        case "1":
          order.SetPaymentMethod(new Cash());
          order.processPayment();
          return;
        case "2":
          order.SetPaymentMethod(new CreditCard());
          order.processPayment();
          return;
        case "3":
          order.SetPaymentMethod(new PayPal());
          order.processPayment();
          return;
        default:
          Console.WriteLine("Please enter a valid option.");
          break;
        }
      }

    }

    public void Undo() {
      order.cancelOrder();
    }

    public void cancel() {
      order.cancelOrder();
    }
  }
}