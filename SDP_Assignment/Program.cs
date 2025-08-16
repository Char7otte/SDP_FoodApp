using SDP_Assignment;
using SDP_Assignment.AccountClasses;
using SDP_Assignment.MenuClasses;
using SDP_Assignment.OrderClasses;
using SDP_Assignment.PaymentClasses;
using SDP_Assignment.CommandClasses;

// Initialize data
Accounts accountsList = DataInitializer.InitializeAccounts();
Console.WriteLine();
Waitress waitress = DataInitializer.InitializeWaitress();

Account? loggedInAccount = new();
Order currentOrder = new();

OrderCommand placeOrder = new PlaceOrder(currentOrder);
OrderCommand payForOrder = new PayForOrder(currentOrder);
OrderCommand alertRestaurant = new AlertRestaurant(currentOrder);
OrderCommand preparingFood = new PreparingFood(currentOrder);
OrderCommand preparingDone = new PreparingDone(currentOrder);
OrderCommand startDelivery = new StartDelivery(currentOrder);

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

void proceedToOrder()
{
    if (!ifWantToOrder())
    {
        currentOrder = new Order(); // Reset the order
        return;
    }

    currentOrder.createOrder();
    if (currentOrder.checkForCancel()) return;

    OrderController controller = new();

    controller.SetCommand(placeOrder);
    controller.SubmitOrder();
    if (currentOrder.checkForCancel()) return;

    controller.SetCommand(payForOrder);
    controller.SubmitOrder();
    if (currentOrder.getState() == "cancelledState") return; //check if restaurant rejected
    if (currentOrder.checkForCancel()) return;

    controller.SetCommand(alertRestaurant);
    controller.SubmitOrder();
    if (currentOrder.getState() == "cancelledState") return; //check if restaurant rejected
    if (currentOrder.checkForCancel()) return;

    controller.SetCommand(preparingFood);
    controller.SubmitOrder();
    currentOrder.cannotCancel();

    controller.SetCommand(preparingDone);
    controller.SubmitOrder();
    currentOrder.cannotCancel();

    controller.SetCommand(startDelivery);
    controller.SubmitOrder();
    currentOrder.cannotCancel();

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
        default:
            invalidInput();
            return false;
    }
}

Order finishDelivery()
{
    currentOrder.delivered();
    return new();
}

#pragma warning disable CS8321 // Local function is declared but never used
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