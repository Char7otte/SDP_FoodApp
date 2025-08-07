using System;

class PreparingDeliveryState : OrderState 
{
    private Order order;

    public PreparingDeliveryState(Order order)
    {
        this.order = order;
    }
    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }


    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed and food is ready.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order already accepted and food is ready.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Food preparation already completed.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Food already completed and ready for delivery.");
    }

    public void deliver()
    {
        Console.WriteLine("Order dispatched for delivery.");
        order.setState(order.DeliveringOrderState);
    }

    public void delivered()
    {
        Console.WriteLine("Cannot mark as delivered - order not dispatched yet.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Cannot cancel order - food is already finished.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - food is already finished.");
    }
}
