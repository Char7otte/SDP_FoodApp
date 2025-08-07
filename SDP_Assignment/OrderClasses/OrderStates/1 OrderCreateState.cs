using System;

namespace SDP_Assignment.OrderClasses.OrderStates
{
    class OrderCreatedState : OrderState
{
    private Order order;

    public OrderCreatedState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("You have confirmed your order.");
        order.setState(order.AwaitingPaymentState);
    }

    public bool canConfirmOrder()
    {
        return true; 
    }

    public void processPayment()
    {
        Console.WriteLine("Cannot process payment - order must be confirmed first.");
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
        Console.WriteLine("Order cancelled by customer.");
        order.setState(order.CancelledState);
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - restaurant has not been notified yet.");
    }
}
}