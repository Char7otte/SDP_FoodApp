public interface OrderState
{
    void createOrder();
    void confirmOrder();
    void processPayment();
    void acceptOrder();
    void startPreparation();
    void foodComplete();
    void deliver();
    void delivered();
    void cancelOrder();
    void rejectOrder();
}
