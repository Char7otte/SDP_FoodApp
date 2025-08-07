using System;

class AcceptedState : OrderState 
{
    private Order order;

    public AcceptedState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed and accepted.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order already accepted by restaurant.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Starting food preparation.");
        order.setState(order.PreparingFoodState);
    }

    public void foodComplete()
    {
        Console.WriteLine("Cannot complete food - preparation has not started.");
    }

    public void deliver()
    {
        Console.WriteLine("Cannot deliver - food is not prepared yet.");
    }

    public void delivered()
    {
        Console.WriteLine("Cannot mark as delivered - order not sent for delivery.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Order cancelled by customer, stopping preparation & refunding.");
        order.setState(order.CancelledState);
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - restaurant already accepted it.");
    }
}