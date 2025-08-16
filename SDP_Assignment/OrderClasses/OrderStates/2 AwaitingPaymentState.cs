using System;
using System.Reflection.Metadata.Ecma335;

class AwaitingPaymentState : OrderState 
{
    private Order order;

    public AwaitingPaymentState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed, awaiting payment.");
    }

    public void processPayment()
    {
        order.pay();
        order.setState(order.RestaurantNotifiedState);
    }

    public void acceptOrder()
    {
        Console.WriteLine("Cannot accept order - payment not processed yet.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Cannot start preparation - payment not processed yet.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Cannot complete food - preparation has not started.");
    }

    public void deliver()
    {
        Console.WriteLine("Cannot deliver - order not prepared yet.");
    }

    public void delivered()
    {
        Console.WriteLine("Cannot mark as delivered - order not sent for delivery.");
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