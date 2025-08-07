using SDP_Assignment.MenuClasses;
using System;

class IdleState : OrderState
{
    private Order order;

    public IdleState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order created.");
        Console.WriteLine();
        order.setState(order.OrderCreatedState);
        
    }

    public void confirmOrder()
    {
        Console.WriteLine("Cannot confirm order - order must be created first.");
    }

    public void processPayment()
    {
        Console.WriteLine("Cannot process payment - order must be created first.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Cannot accept order - order is still being created.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Cannot start preparation - order must be confirmed first.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Cannot complete food - preparation has not started.");
    }

    public void deliver()
    {
        Console.WriteLine("Cannot deliver - order is not ready.");
    }

    public void delivered()
    {
        Console.WriteLine("Cannot mark as delivered - order has not been sent for delivery.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Cannot cancel order - order has not been created.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - restaurant has not been notified yet.");
    }
}