using SDP_Assignment.MenuClasses;
using SDP_Assignment.OrderClasses.OrderStates;
using SDP_Assignment.PaymentClasses;
using System;
using System.Collections.Generic;

public class Order
{
    public OrderState IdleState { get; set; }
    public OrderState OrderCreatedState { get; set; }
    public OrderState AwaitingPaymentState { get; set; }
    public OrderState RestaurantNotifiedState { get; set; }
    public OrderState AcceptedState { get; set; }
    public OrderState PreparingFoodState { get; set; }
    public OrderState PreparingDeliveryState { get; set; }
    public OrderState DeliveringOrderState { get; set; }
    public OrderState OrderCompletedState { get; set; }
    public OrderState CancelledState { get; set; }

    private OrderState state;
    private List<MenuItem> menuItems;
    private Payment paymentMethod;


    public DateTime OrderCreationDate {  get; set; }

    public Order()
    {
        IdleState = new IdleState(this);
        OrderCreatedState = new OrderCreatedState(this);
        AwaitingPaymentState = new AwaitingPaymentState(this);
        RestaurantNotifiedState = new RestaurantNotifiedState(this);
        AcceptedState = new AcceptedState(this);
        PreparingFoodState = new PreparingFoodState(this);
        PreparingDeliveryState = new PreparingDeliveryState(this);
        DeliveringOrderState = new DeliveringOrderState(this);
        OrderCompletedState = new OrderCompletedState(this);
        CancelledState = new CancelledState(this);

        OrderCreationDate = new(); //This will be set when the order is delivered
        state = IdleState;
        menuItems = new();
    }

    public void SetPaymentMethod(Payment payment)
    {
        paymentMethod = payment;
    }

    public void pay()
    {
        var cost = calculateCost();
        paymentMethod.Pay(cost);
    }

    public string getState()
    {
        return this.state.GetType().Name;
    }

    public void setState(OrderState state)
    {
        this.state = state;
    }

    public void addFood(MenuItem item) => menuItems.Add(item);

    public void getFood()
    {
        foreach(var item in menuItems)
        {
            item.print();
        }
    }

    public void setDate()
    {
        OrderCreationDate = DateTime.Now;
    }

    public double calculateCost()
    {
        double cost = 0;
        foreach (var item in menuItems)
        {
            cost += item.Price;
        }
        return cost;
    }


    public void createOrder()
    {
        state.createOrder();
    }

    public void confirmOrder()
    {
        state.confirmOrder();
    }

    public void processPayment()
    {
        state.processPayment();
    }

    public void acceptOrder()
    {
        state.acceptOrder();
    }

    public void startPreparation()
    {
        state.startPreparation();
    }

    public void foodComplete()
    {
        state.foodComplete();
    }

    public void deliver()
    {
        state.deliver();
    }

    public void delivered()
    {
        state.delivered();
    }

    public void cancelOrder()
    {
        state.cancelOrder();
    }

    public void rejectOrder()
    {
        state.rejectOrder();
    }
}