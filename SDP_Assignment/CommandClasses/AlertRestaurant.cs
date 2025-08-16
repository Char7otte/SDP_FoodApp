using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDP_Assignment.PaymentClasses;

namespace SDP_Assignment.CommandClasses {
  public class AlertRestaurant: OrderCommand {
    private Order order;

    public AlertRestaurant(Order order) {
      this.order = order;
    }

    public void Execute() {
      Console.WriteLine("Notifying restaurant. Please hold...");
      Console.ReadLine();
      Random rng = new Random();
      if (rng.Next(1, 11) == 1) 
      {
        Console.WriteLine("Restaurant is unable to fulfill this order. We are sorry for the inconvenience.");
        order.rejectOrder();
        return;
      }

      order.acceptOrder();
      return;
    }

    public void Undo() {
      order.cancelOrder();
    }

    public void cancel() {
      order.cancelOrder();
    }
  }
}