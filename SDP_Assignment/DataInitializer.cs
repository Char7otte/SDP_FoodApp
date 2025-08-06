using SDP_Assignment.Menus;
using SDP_Assignment.AccountFolder;

namespace SDP_Assignment
{
    internal static class DataInitializer
    {
        public static Accounts InitializeAccounts()
        {
            Accounts accountsList = new();
            Account accountJerry = new("Jerry", "123");
            Account accountMary = new("Mary", "abc");
            Account accountJared = new("Jared", "xyz");
            accountsList.addAccount(accountJerry);
            accountsList.addAccount(accountMary);
            accountsList.addAccount(accountJared);
            return accountsList;
        }

        public static MenuComponent InitializeRestaurants()
        {
            // DP Diner Restaurant
            MenuComponent breakfastMenu = new DinerMenu("Breakfast");
            breakfastMenu.add(new MenuItem("Blueberry Pancakes", "Pancakes made with fresh blueberries and maple syrup", true, 3.99));
            breakfastMenu.add(new MenuItem("BLT", "Classic bacon,lettuce and tomato sandwich on whole wheat toast", false, 3.49));

            MenuComponent mainsMenu = new DinerMenu("Mains");
            mainsMenu.add(new MenuItem("Veggie Spaghetti", "Spaghetti with mushrooms, spinach and tomatoes", true, 5.99));
            MenuComponent chickenMenu = new DinerMenu("Chicken");
            chickenMenu.add(new MenuItem("Crispy Fried Chicken", "Kampung chicken deep-fried to perfection in beerbatter", false, 8.99));
            chickenMenu.add(new MenuItem("Roast Chicken", "Slow-roasted rotisserie chicken with honey glaze", false, 10.49));
            mainsMenu.add(chickenMenu);

            MenuComponent dpDiner = new DinerMenu("DP Diner");
            dpDiner.add(breakfastMenu);
            dpDiner.add(mainsMenu);

            // Bella Italia Restaurant
            MenuComponent appetizerMenu = new DinerMenu("Appetizers");
            appetizerMenu.add(new MenuItem("Bruschetta", "Grilled bread topped with fresh tomatoes, basil and garlic", true, 6.99));
            appetizerMenu.add(new MenuItem("Antipasto Platter", "Selection of cured meats, cheeses and olives", false, 12.99));

            MenuComponent pastaMenu = new DinerMenu("Pasta");
            pastaMenu.add(new MenuItem("Margherita Pasta", "Fresh pasta with tomato sauce, mozzarella and basil", true, 14.99));
            pastaMenu.add(new MenuItem("Carbonara", "Creamy pasta with pancetta, eggs and parmesan", false, 16.99));
            pastaMenu.add(new MenuItem("Seafood Linguine", "Linguine with mussels, prawns and calamari", false, 19.99));

            MenuComponent pizzaMenu = new DinerMenu("Pizza");
            pizzaMenu.add(new MenuItem("Margherita Pizza", "Classic pizza with tomato, mozzarella and basil", true, 13.99));
            pizzaMenu.add(new MenuItem("Pepperoni Pizza", "Pepperoni with mozzarella cheese", false, 15.99));
            pizzaMenu.add(new MenuItem("Quattro Stagioni", "Four seasons pizza with ham, mushrooms, artichokes and olives", false, 17.99));

            MenuComponent bellaItalia = new DinerMenu("Bella Italia");
            bellaItalia.add(appetizerMenu);
            bellaItalia.add(pastaMenu);
            bellaItalia.add(pizzaMenu);

            // Tokyo Sushi Bar
            MenuComponent sushiMenu = new DinerMenu("Sushi & Sashimi");
            sushiMenu.add(new MenuItem("Salmon Sashimi", "Fresh Norwegian salmon slices", false, 8.99));
            sushiMenu.add(new MenuItem("Tuna Nigiri", "Fresh tuna over seasoned rice", false, 9.99));
            sushiMenu.add(new MenuItem("Avocado Roll", "Fresh avocado with cucumber", true, 6.99));

            MenuComponent ramenMenu = new DinerMenu("Ramen");
            ramenMenu.add(new MenuItem("Tonkotsu Ramen", "Rich pork bone broth with chashu pork", false, 13.99));
            ramenMenu.add(new MenuItem("Miso Ramen", "Fermented soybean paste broth with vegetables", true, 12.99));
            ramenMenu.add(new MenuItem("Spicy Miso Ramen", "Spicy miso broth with ground pork", false, 14.99));

            MenuComponent bentoMenu = new DinerMenu("Bento Boxes");
            bentoMenu.add(new MenuItem("Chicken Teriyaki Bento", "Grilled chicken with teriyaki sauce, rice and sides", false, 11.99));
            bentoMenu.add(new MenuItem("Tofu Katsu Bento", "Breaded and fried tofu with vegetables and rice", true, 10.99));

            MenuComponent tokyoSushiBar = new DinerMenu("Tokyo Sushi Bar");
            tokyoSushiBar.add(sushiMenu);
            tokyoSushiBar.add(ramenMenu);
            tokyoSushiBar.add(bentoMenu);

            // Spice Route (Indian Restaurant)
            MenuComponent startersMenu = new DinerMenu("Starters");
            startersMenu.add(new MenuItem("Samosas", "Crispy pastries filled with spiced potatoes and peas", true, 5.99));
            startersMenu.add(new MenuItem("Chicken Tikka", "Marinated chicken grilled in tandoor oven", false, 8.99));

            MenuComponent curriesMenu = new DinerMenu("Curries");
            curriesMenu.add(new MenuItem("Butter Chicken", "Tender chicken in creamy tomato curry", false, 16.99));
            curriesMenu.add(new MenuItem("Dal Tadka", "Yellow lentils tempered with spices", true, 12.99));
            curriesMenu.add(new MenuItem("Lamb Vindaloo", "Spicy Goan curry with tender lamb", false, 18.99));

            MenuComponent breadsMenu = new DinerMenu("Indian Breads");
            breadsMenu.add(new MenuItem("Garlic Naan", "Leavened bread with garlic and herbs", true, 3.99));
            breadsMenu.add(new MenuItem("Chapati", "Traditional whole wheat flatbread", true, 2.99));

            MenuComponent spiceRoute = new DinerMenu("Spice Route");
            spiceRoute.add(startersMenu);
            spiceRoute.add(curriesMenu);
            spiceRoute.add(breadsMenu);

            // Green Garden Cafe (Vegetarian/Vegan)
            MenuComponent saladMenu = new DinerMenu("Fresh Salads");
            saladMenu.add(new MenuItem("Quinoa Power Bowl", "Quinoa with mixed greens, avocado and tahini dressing", true, 11.99));
            saladMenu.add(new MenuItem("Mediterranean Salad", "Mixed greens with olives, feta and olive oil", true, 10.99));

            MenuComponent smoothieMenu = new DinerMenu("Smoothies & Bowls");
            smoothieMenu.add(new MenuItem("Acai Bowl", "Acai berries with granola and fresh fruits", true, 9.99));
            smoothieMenu.add(new MenuItem("Green Goddess Smoothie", "Spinach, banana, mango and coconut milk", true, 7.99));

            MenuComponent veganMainsMenu = new DinerMenu("Plant-Based Mains");
            veganMainsMenu.add(new MenuItem("Buddha Bowl", "Brown rice with roasted vegetables and tahini", true, 13.99));
            veganMainsMenu.add(new MenuItem("Lentil Walnut Bolognese", "Rich lentil sauce over zucchini noodles", true, 14.99));

            MenuComponent greenGarden = new DinerMenu("Green Garden Cafe");
            greenGarden.add(saladMenu);
            greenGarden.add(smoothieMenu);
            greenGarden.add(veganMainsMenu);

            // Create main restaurant collection
            MenuComponent allRestaurants = new DinerMenu("Restaurant Directory");
            allRestaurants.add(dpDiner);
            allRestaurants.add(bellaItalia);
            allRestaurants.add(tokyoSushiBar);
            allRestaurants.add(spiceRoute);
            allRestaurants.add(greenGarden);

            return allRestaurants;
        }

        public static Waitress InitializeWaitress()
        {
            MenuComponent allRestaurants = InitializeRestaurants();
            return new Waitress(allRestaurants);
        }
    }
}