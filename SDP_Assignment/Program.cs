using SDP_Assignment;
using SDP_Assignment.AccountClasses;
using SDP_Assignment.MenuClasses;
using SDP_Assignment.OrderClasses;
using SDP_Assignment.PaymentClasses;

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
    Console.WriteLine("=== RESTAURANT SELECTION ===");
    
    MenuComponent allRestaurants = waitress.AllMenus;
    List<MenuComponent> restaurants = new List<MenuComponent>();
    
    var index = 0;
    while (true) 
    {
        try
        {
            //Get child & add to index until out of range error is thrown to find length
            MenuComponent restaurant = allRestaurants.getChild(index);
            restaurants.Add(restaurant);
            Console.WriteLine($"{index + 1}. {restaurant.Name}");
            index++;
        }
        catch (ArgumentOutOfRangeException)
        {
            break;
        }
    }
    
    if (restaurants.Count == 0)
    {
        Console.WriteLine("No restaurants available.");
        return;
    }
    
    Console.WriteLine("0. Back to main menu");
    Console.Write("Select a restaurant: ");
    
    var input = Console.ReadLine();
    
    if (input == "0")
    {
        return;
    }
    
    if (int.TryParse(input, out int restaurantChoice) && restaurantChoice >= 1 && restaurantChoice <= restaurants.Count)
    { 
        MenuComponent selectedRestaurant = restaurants[restaurantChoice - 1];
        browseMenuCategories(selectedRestaurant);
    }
    else
    {
        invalidInput();
        browseRestaurants();
    }
}

void browseMenuCategories(MenuComponent restaurant)
{
    Console.WriteLine();
    Console.WriteLine($"=== {restaurant.Name.ToUpper()} - MENU CATEGORIES ===");
    
    List<MenuComponent> categories = new List<MenuComponent>();
    int categoryIndex = 0;
    
    while (true)
    {
        try
        {
            MenuComponent category = restaurant.getChild(categoryIndex);
            categories.Add(category);
            Console.WriteLine($"{categoryIndex + 1}. {category.Name}");
            categoryIndex++;
        }
        catch (ArgumentOutOfRangeException)
        {
            break;
        }
    }
    
    if (categories.Count == 0)
    {
        Console.WriteLine("No menu categories available.");
        Console.WriteLine("0. Back to restaurant selection");
        Console.ReadLine();
        browseRestaurants();
        return;
    }
    
    Console.WriteLine("0. Back to restaurant selection");
    Console.Write("Select a menu category: ");
    
    var input = Console.ReadLine();
    
    if (input == "0")
    {
        browseRestaurants();
        return;
    }
    
    if (int.TryParse(input, out int categoryChoice) && categoryChoice >= 1 && categoryChoice <= categories.Count)
    {
        MenuComponent selectedCategory = categories[categoryChoice - 1];
        browseMenuItems(restaurant, selectedCategory);
    }
    else
    {
        invalidInput();
        browseMenuCategories(restaurant);
    }
}

void browseMenuItems(MenuComponent restaurant, MenuComponent category)
{

    Console.WriteLine();
    Console.WriteLine($"=== {restaurant.Name.ToUpper()} - {category.Name.ToUpper()} ===");

    List<MenuComponent> menuItems = new List<MenuComponent>();
    collectMenuItems(category, menuItems);

    if (menuItems.Count == 0)
    {
        Console.WriteLine("No items found in this category.");
        Console.WriteLine("0. Back to menu categories");
        Console.ReadLine();
        browseMenuCategories(restaurant);
        return;
    }

    for (int i = 0; i < menuItems.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {menuItems[i].Name} - ${menuItems[i].Price:F2}");
        Console.WriteLine($"    {menuItems[i].Description}");
        if (menuItems[i].Vegetarian)
        {
            Console.WriteLine("    (Vegetarian)");
        }
        Console.WriteLine();
    }

    Console.WriteLine("0. Back to menu categories");
    Console.Write("Select an item to add to your order (or 0 to go back): ");

    var input = Console.ReadLine();

    if (input == "0")
    {
        browseMenuCategories(restaurant);
        return;
    }

    if (int.TryParse(input, out int itemChoice) && itemChoice >= 1 && itemChoice <= menuItems.Count)
    {
        MenuComponent selectedItem = menuItems[itemChoice - 1];

        try
        {
            double price = selectedItem.Price; // This will throw an error if it's not a MenuItem, meaning it's still not a leaf yet

            Console.WriteLine($"Added {selectedItem.Name} to your order!");
            MenuItem downcastedItem = selectedItem as MenuItem; //Downcasting from MenuComponent to MenuItem

            currentOrder.addFood(downcastedItem);

            Console.WriteLine("Would you like to add more items? (Y/N)");
            var continueInput = Console.ReadLine()?.ToUpper();

            if (continueInput == "Y")
            {
                browseMenuItems(restaurant, category);
            }
            else
            {
                proceedToOrder();
            }
        }
        catch (NotSupportedException)
        {
            // This is a submenu, not an item
            browseMenuItems(restaurant, selectedItem);
        }
    }
    else
    {
        invalidInput();
        browseMenuItems(restaurant, category);
    }
    
}

void collectMenuItems(MenuComponent menu, List<MenuComponent> items)
{
    int index = 0;
    while (true)
    {
        try
        {
            MenuComponent child = menu.getChild(index);
            
            // Check if this is a MenuItem or another menu
            try
            {
                double price = child.Price; // If this succeeds, it's a MenuItem
                items.Add(child);
            }
            catch (NotSupportedException)
            {
                // This is a submenu, recursively collect its items
                collectMenuItems(child, items);
            }
            
            index++;
        }
        catch (ArgumentOutOfRangeException)
        {
            break;
        }
    }
}

//void startOrderWithItem(MenuComponent selectedItem)
//{
//    currentOrder = new Order();
//    MenuItem itemToAdd = new MenuItem(selectedItem.Name, selectedItem.Description, selectedItem.Vegetarian, selectedItem.Price);
//    currentOrder.addFood(itemToAdd);
//    currentOrder.createOrder();
//}

void proceedToOrder()
{
    if (!ifWantToOrder())
    {
        currentOrder = new Order(); // Reset the order
        return;
    }
     

    currentOrder.createOrder();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    var input = Console.ReadLine();
    if (input == "0")
    { 
        currentOrder.cancelOrder();
        return;
    }

    currentOrder = confirmOrder();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }

    currentOrder = payment();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }

    currentOrder = notifyRestaurant();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    if (currentOrder.getState() == "CancelledState") //Check if the restaurant rejected the order
    {
        return;
    }
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }
    else 

        currentOrder = startPreparing();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = finishPreparing();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = startDelivery();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = finishDelivery();
    Console.WriteLine();
    Console.ReadLine();

    afterLoggedIn();

}

bool ifWantToOrder() 
{
    Console.WriteLine("Would you like to proceed with your order? (Y/N)");
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

void startOrder()
{
    waitress.printMenu();
    if (ifWantToOrder()) 
    {
        currentOrder = createOrder();
    }
    else 
    {
        return;
    }

    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    var input = Console.ReadLine();
    if (input == "0")
    { 
        currentOrder.cancelOrder();
        return;
    }


    currentOrder = confirmOrder();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }

    currentOrder = payment();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    if (currentOrder.getState() == "CancelledState") //Check if the restaurant rejected the order
    {
        return;
    }
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }

    currentOrder = notifyRestaurant();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    if (currentOrder.getState() == "CancelledState") //Check if the restaurant rejected the order
    {
        return;
    }
    Console.WriteLine("Enter 0 if you would like to cancel your order.");
    input = Console.ReadLine();
    if (input == "0")
    {
        currentOrder.cancelOrder();
        return;
    }
    else 

        currentOrder = startPreparing();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = finishPreparing();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = startDelivery();
    Console.WriteLine();
    Console.WriteLine($"The order state is: {currentOrder.getState()}");
    Console.WriteLine("The order can no longer be cancelled.");

    currentOrder = finishDelivery();
    Console.WriteLine();
    Console.ReadLine();

    afterLoggedIn();
}

Order createOrder()
{
    Order order = new();

    while (true)
    {
        Console.WriteLine();
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
    Console.WriteLine("YOUR ORDER: ");
    currentOrder.getFood();
    Console.Write("TOTAL PRICE: $");
    Console.WriteLine(currentOrder.calculateCost());
    Console.WriteLine("Are you sure this is your order?(Y/N)");
    
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
    else
    {
        Console.WriteLine("Invalid input. Order not confirmed.");
        confirmOrder();
    }

    return currentOrder;
}

Order payment()
{
    while (true)
    {
        Console.WriteLine("Select payment method: ");
        Console.WriteLine("1. Cash");
        Console.WriteLine("2. Credit Card");
        Console.WriteLine("3. PayPal");
        Console.WriteLine("0. Exit");
        var input = Console.ReadLine();

        if (input == "0")
        {
            currentOrder.cancelOrder();
            return currentOrder;
        }

        Payment paymentMethod = null;

        switch(input)
        {
            case "1":
                paymentMethod = new Cash();
                break;
            case "2":
                paymentMethod = new CreditCard();
                break;
            case "3":
                paymentMethod = new PayPal();
                break;
            default:
                invalidInput();
                Console.ReadLine();
                payment();
                break;
        }

        currentOrder.SetPaymentMethod(paymentMethod);
        currentOrder.processPayment();
        return currentOrder;
    }



    //while (true)
    //{
    //    Console.WriteLine("Scan the PayNow! QR code below to pay for the food:");
    //    Console.WriteLine("\n┌─────────────────────────┐");
    //    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    //    Console.WriteLine("│ ██  ██    ██    ██  ██ │");
    //    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    //    Console.WriteLine("│         ██  ██         │");
    //    Console.WriteLine("│ ██  ██    ██  ██    ██ │");
    //    Console.WriteLine("│   ██  ██████  ██  ██   │");
    //    Console.WriteLine("│ ██    ██  ██    ██  ██ │");
    //    Console.WriteLine("│   ██████    ██████  ██ │");
    //    Console.WriteLine("│ ██    ██  ██  ██    ██ │");
    //    Console.WriteLine("│         ██  ██         │");
    //    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    //    Console.WriteLine("│ ██  ██    ██    ██  ██ │");
    //    Console.WriteLine("│ ██████  ██  ██  ██████ │");
    //    Console.WriteLine("└─────────────────────────┘");
    //    Console.ReadLine();
    //    Console.WriteLine("Please hold...");
    //    Console.ReadLine();

    //    if (!paymentSuccess())
    //    {
    //        Console.WriteLine("Payment failure. Please try again.");
    //        continue;
    //    }
    //    Console.WriteLine("Payment success.");
    //    Console.WriteLine($"${currentOrder.calculateCost()} has been taken from your account");
    //    Console.ReadLine();

    //    currentOrder.processPayment();
    //    break;
    //}
    //return currentOrder;
}

bool paymentSuccess()
{
    //Simulate payment. Has 10% chance to fail
    var rand = new Random();
    int randomNumber = rand.Next(1, 11);
    if (randomNumber == 1) return false;
    return true;
}

Order notifyRestaurant()
{
    Console.WriteLine("Notifying restaurant. Please hold...");
    Console.ReadLine();
    if (!paymentSuccess()) //Hijacking the RNG function to simulate the restaurant denying the order
    {
        Console.WriteLine("Restaurant is unable to fulfill this order. We are sorry for the inconvenience.");
        currentOrder.rejectOrder();
        return currentOrder;
    }

currentOrder.acceptOrder();
    return currentOrder;
}

Order startPreparing()
{
    Console.WriteLine("Restaurant is now preparing your food...");
    Console.ReadLine();
    currentOrder.startPreparation();
    return currentOrder;
}

Order finishPreparing()
{
    Console.WriteLine("...");
    Console.ReadLine();

    currentOrder.foodComplete();
    return currentOrder;
}

Order startDelivery()
{
    Console.WriteLine("Delivery has started.");
    Console.ReadLine();

    currentOrder.deliver();
    return currentOrder;
}

Order finishDelivery()
{
    currentOrder.delivered();
    return new();
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

