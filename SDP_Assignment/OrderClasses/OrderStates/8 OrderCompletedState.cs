using System;

class OrderCompletedState : OrderState
{
    private Order order;

    public OrderCompletedState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already completed.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed and order completed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order already completed.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Order already completed.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Order already completed.");
    }

    public void deliver()
    {
        Console.WriteLine("Order already delivered and completed.");
    }

    public void delivered()
    {
        Console.WriteLine("Order already marked as delivered and completed.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Cannot cancel order - order already completed.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - order already completed.");
    }

}
