using SDP_Assignment;
using SDP_Assignment.AccountClasses;
using SDP_Assignment.MenuClasses;
using SDP_Assignment.OrderClasses;
// Initialize data
Accounts accountsList = DataInitializer.InitializeAccounts();
Console.WriteLine();
Waitress waitress = DataInitializer.InitializeWaitress();


Account? loggedInAccount = new();
Order currentOrder = new();

startScreen();

void startScreen()
{
    while (loggedInAccount?.ToString() == "" || loggedInAccount == null)
    {
        Console.WriteLine();
        Console.WriteLine("1. Register new account");
        Console.WriteLine("2. Login");
        //Console.WriteLine("3. Browse restaurants");
        var input = Console.ReadLine();
        Console.WriteLine();

        switch (input)
        {
            case "1":
                loggedInAccount = accountsList.register();
                break;
            case "2":
                loggedInAccount = accountsList.login();
                break;
            //case "3":
            //    browseRestaurants();
            //    break;
            default:
                invalidInput();
                break;
        }
    }

    afterLoggedIn();
}

void afterLoggedIn()
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine($"Welcome,{loggedInAccount?.Username}.");        
        Console.WriteLine("1. Browse restaurants");
        Console.WriteLine("0. Logout");
        var input = Console.ReadLine();

        switch (input)
        {
            
            case "1":
                browseRestaurants();
                break;
            case "0":
                loggedInAccount = new();
                startScreen();
                break;
            default:
                break;
        }
    }
}

void browseRestaurants()
{
    Console.WriteLine();
    Console.WriteLine("1. Browse everything");
    Console.WriteLine("2. Browse by restaurant");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            waitress.printMenu();
            if (ifWantToOrder()) currentOrder = createOrder();

            if (currentOrder == null || currentOrder.ToString() == "") break;
            Console.WriteLine($"The order state is: {currentOrder.getState()}");
            currentOrder = confirmOrder();

            if (currentOrder == null || currentOrder.ToString() == "") break;
            Console.WriteLine($"The order state is: {currentOrder.getState()}");
            currentOrder = payment();
            break;
        case "2":
            break;
        default:
            invalidInput();
            break;
    }
}

bool ifWantToOrder() 
{
    Console.WriteLine("Would you like to order? (Y/N)");
    var input = Console.ReadLine()?.ToUpper();

    switch (input) 
    {
        case "Y":
            return true;
        case "N":
            return false;
        default :
            invalidInput();
            return false;
    }
}

Order createOrder()
{
    Order order = new();

    while (true)
    {
        Console.WriteLine("Please enter what you would like to order, one at a time.");
        Console.WriteLine("Enter 0 to finish selecting your order.");
        Console.WriteLine($"You have ordered:");
        order.getFood();

        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Please enter a valid food.");
            continue;
        }
        else if (input == "0")
        {
            break;
        }

        MenuItem itemToAdd = new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries and maple syrup", true, 3.99);
        order.addFood(itemToAdd);
    }

    order.createOrder();
    return order;
}

Order confirmOrder()
{
    Console.WriteLine("Are you sure this is your order?(Y/N)");
    Console.Write("TOTAL PRICE: $");
    Console.WriteLine(currentOrder.calculateCost());
    currentOrder.getFood();
    var input = Console.ReadLine()?.ToUpper();

    if (input == "Y")
    {
        currentOrder.confirmOrder();
    }
    else if (input == "N")
    {
        Console.WriteLine("Cancelling order");
        currentOrder.cancelOrder();
    }

    return currentOrder;
}

Order payment()
{
    Console.WriteLine("Scan the PayNow! QR code below to pay for the food:");
    Console.WriteLine("\n┌─────────────────────────┐");
    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    Console.WriteLine("│ ██  ██    ██    ██  ██ │");
    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    Console.WriteLine("│         ██  ██         │");
    Console.WriteLine("│ ██  ██    ██  ██    ██ │");
    Console.WriteLine("│   ██  ██████  ██  ██   │");
    Console.WriteLine("│ ██    ██  ██    ██  ██ │");
    Console.WriteLine("│   ██████    ██████  ██ │");
    Console.WriteLine("│ ██    ██  ██  ██    ██ │");
    Console.WriteLine("│         ██  ██         │");
    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    Console.WriteLine("│ ██  ██    ██    ██  ██ │");
    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    Console.WriteLine("└─────────────────────────┘");
    Console.ReadLine();
    Console.WriteLine("Please hold...");
    Console.ReadLine();
    if (paymentSuccess())
    {
        Console.WriteLine("Payment success.");
        Console.WriteLine($"${currentOrder.calculateCost()} has been taken from your account");
        Console.ReadLine();

        currentOrder.processPayment();
    }
    else
    {
        Console.WriteLine("Payment failure. Please try again.");
        currentOrder.cancelOrder();
    }
    return currentOrder;
}

bool paymentSuccess()
{
    var rand = new Random();
    int randomNumber = rand.Next(1, 11);
    if (randomNumber == 1) return false;
    return true;
}



#pragma warning disable CS8321 // Local function is declared but never used
//this is the dumbest warning to exist
void notImplemented()
{
    Console.WriteLine("NOT IMPLEMENTED");
    Console.WriteLine("NOT IMPLEMENTED");
    Console.WriteLine("NOT IMPLEMENTED");
    Console.WriteLine("NOT IMPLEMENTED");
    Console.WriteLine("NOT IMPLEMENTED");
}
#pragma warning restore CS8321 // Local function is declared but never used

void invalidInput()
{
    Console.WriteLine("Please enter a valid option.");
}

