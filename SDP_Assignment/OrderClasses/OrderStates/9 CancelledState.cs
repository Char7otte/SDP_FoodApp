using System;

class CancelledState : OrderState
{
    private Order order;

    public CancelledState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void processPayment()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void deliver()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void delivered()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Order is cancelled.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Order is cancelled.");
    }
}
