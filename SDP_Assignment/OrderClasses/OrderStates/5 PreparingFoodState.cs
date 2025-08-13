using System;

class PreparingFoodState : OrderState 
{
    private Order order;

    public PreparingFoodState(Order order)
    {
        this.order = order;
    }

    public void createOrder()
    {
        Console.WriteLine("Order already created.");
    }

    public void confirmOrder()
    {
        Console.WriteLine("Order already confirmed and is being prepared.");
    }

    public void processPayment()
    {
        Console.WriteLine("Payment already processed.");
    }

    public void acceptOrder()
    {
        Console.WriteLine("Order already accepted and is being prepared.");
    }

    public void startPreparation()
    {
        Console.WriteLine("Food preparation already in progress.");
    }

    public void foodComplete()
    {
        Console.WriteLine("Restaurant has finished making your food.");
        Console.WriteLine("Please wait while we get ready for delivery.");
        order.setState(order.PreparingDeliveryState);
    }

    public void deliver()
    {
        Console.WriteLine("Cannot deliver - food is still being prepared.");
    }

    public void delivered()
    {
        Console.WriteLine("Cannot mark as delivered - food not ready for delivery.");
    }

    public void cancelOrder()
    {
        Console.WriteLine("Cannot cancel order - preparation has started.");
    }

    public void rejectOrder()
    {
        Console.WriteLine("Cannot reject order - restaurant already accepted.");
    }
}
