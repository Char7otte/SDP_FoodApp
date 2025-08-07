using SDP_Assignment;
using SDP_Assignment.AccountClasses;
using SDP_Assignment.MenuClasses;

// Initialize data
Accounts accountsList = DataInitializer.InitializeAccounts();
Console.WriteLine();
Waitress waitress = DataInitializer.InitializeWaitress();
Account? loggedInAccount = new();

startScreen();

void startScreen()
{
    while (loggedInAccount?.ToString() == "")
    {
        Console.WriteLine();
        Console.WriteLine("1. Register new account");
        Console.WriteLine("2. Login");
        Console.WriteLine("3. Browse restaurants");
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
            case "3":
                browseRestaurants();
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
        Console.WriteLine($"Welcome,{loggedInAccount?.Username}.");
        Console.WriteLine("0. Logout");
        Console.WriteLine("1. Browse restaurants");
        var input = Console.ReadLine();

        switch (input)
        {
            case "0":
                loggedInAccount = new();
                startScreen();
                break;
            case "1":
                browseRestaurants();
                break;
            default:
                break;
        }
    }
}

void browseRestaurants()
{
    Console.WriteLine("1. Browse everything");
    Console.WriteLine("2. Browse by restaurant");
    Console.WriteLine("3. Browse vegetarian options");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            waitress.printMenu();
            break;
        case "2":
            break;
        case "3":
        waitress.printVegetarianMenu();
            break;
        default:
            invalidInput();
            break;
    }
    





    waitress.printMenu();
}

// void notImplemented()
// {
//     Console.WriteLine("NOT IMPLEMENTED");
//     Console.WriteLine("NOT IMPLEMENTED");
//     Console.WriteLine("NOT IMPLEMENTED");
//     Console.WriteLine("NOT IMPLEMENTED");
//     Console.WriteLine("NOT IMPLEMENTED");
// }

void invalidInput()
{
    Console.WriteLine("Please enter a valid option.");
}

