using System;

class DeliveringOrderState : OrderState 
{
    private Order order;

    public DeliveringOrderState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed and out for delivery.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order already accepted and out for delivery.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Food preparation already completed.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Food already completed and out for delivery.");
    }

    public void deliver()
    {
        Console.WriteLine("Order already dispatched for delivery.");
    }

    public void delivered()
    {
        order.setDate();

        Console.WriteLine("Order delivered successfully!");
        Console.WriteLine($"Order details have been archived on {order.OrderCreationDate}");
        Console.WriteLine($"It will be deleted on: {order.OrderCreationDate.AddYears(1)}");

        order.setState(order.OrderCompletedState);
    }

    public void cancelOrder()
    {
        Console.WriteLine("Cannot cancel order - food already out for delivery.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - food already out for delivery.");
    }
}
