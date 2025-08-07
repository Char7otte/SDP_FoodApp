using System;

class RestaurantNotifiedState : OrderState 
{
    private Order order;

    public RestaurantNotifiedState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed and payment processed.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Restaurant accepted the order. Ready for preparation.");
        order.setState(order.AcceptedState);
    }

    public void startPreparation()
    {
        Console.WriteLine("Cannot start preparation - restaurant must accept order first.");
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
        Console.WriteLine("Order cancelled by customer, refunding payment.");
        order.setState(order.CancelledState);
    }

    public void rejectOrder()
    {
        Console.WriteLine("Order rejected by restaurant, refunding payment.");
        order.setState(order.CancelledState);
    }
}