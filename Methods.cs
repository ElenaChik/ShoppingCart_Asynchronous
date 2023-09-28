using System;
using System.Xml.Linq;

namespace AdvancedShoppingCart;
using static Display;

public static class Methods
{
    static string? selection;
    static User? newUser;
    static Customer? customer;
    static Admin? admin;

    public static void SearchItem()
    {
        Print("Write item Name ");
        var count = 0;
        string searchName = Console.ReadLine();

        foreach (Item item in Item.Items)
            if (item.Name == searchName)
            {
                Print("Your item is: " + item.Name + " price: " + item.Price + "$");
                count++;
                break;
            }
           
            if (count == 0) 
            {
                Print("Your item is not found");
            }
    }

    public static void Print(string text)
    {
        Console.WriteLine(text);
    }

    public static void Register()
    {
        Print("Enter your username: ");
        string? uname = Console.ReadLine();
        Print("Enter your Password: ");
        string pwd = ReadPassword();
        customer = new Customer(uname, pwd);
        User.Users.Add(customer);
        Print($"{customer} successfully registered! Please log in to continue");
    }

    public static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo presseKey;
        do
        {
            presseKey = Console.ReadKey(true);
            if (presseKey.Key != ConsoleKey.Backspace && presseKey.Key != ConsoleKey.Enter)
            {
                password += presseKey.KeyChar;
                Console.Write("*");
            }
            else
            {
                if (presseKey.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
                else if (presseKey.Key == ConsoleKey.Enter)
                {
                    break;
                }
            }
        } while (presseKey.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }

    public static async Task Login()
    {
        Print("Enter your username: ");
        string? uname = Console.ReadLine();
        Print("Enter your Password: ");
        string pwd = ReadPassword();
        newUser = new User(uname, pwd);
        newUser = Validate(newUser);
        if (newUser != null)
        {
            await LoginSetup();
            Print($"\nHi {newUser}!");
            do
            {
                if (newUser.Isadmin)
                {
                    admin = new Admin(newUser);
                    ALoggedinPage();
                    selection = Console.ReadLine();

                    switch (selection)
                    {
                        case "1"://View items
                            ItemsListing();
                            break;
                        case "2"://create new items
                            CreateNewItem();
                            break;
                        case "3"://remove items
                            DeleteItem();
                            break;
                        case "4"://search item
                            SearchItem();
                            break;
                    }
                }
                else
                {
                    customer = new Customer(newUser);
                    CLoggedinPage();
                    selection = Console.ReadLine();

                    switch (selection)
                    {
                        case "1"://view cart
                            ViewCart();
                            break;
                        case "2"://add items to cart
                            AddToCart();
                            break;
                        case "3"://search item
                            SearchItem();
                            break;
                    }
                }     
            } while (selection != "0");//if 0, back to previous menu

        }
        else
        {
            Print("Incorrect username or password");
            return;
        }
    }

    public static async Task Logout()
    {
        await LogoutSetup();
    }

    public static User Validate(User temp)
    {
        foreach(User user in User.Users)
        {
            if (user.compareUser(temp))
                return user;
        }
        return null;
    }

    public static void AddToCart()
    {
        ItemsListing();
        Print("Please enter the id of desired item:");
        selection = Console.ReadLine();
        int id = Convert.ToInt32(selection);
        customer.AddItems(Item.Items[id - 1]);
        Print($"{Item.Items[id - 1]} added to cart\n");
    }

    public static void ViewCart()
    {
        customer.DisplayCart();
        if (customer.CartItems.Count > 0)
        {
            Print("Select 1 to checkout or 2 to return to previous menu");
            selection = Console.ReadLine();
            if (selection == "1")
                customer.Checkout();
        }
        else return;
    }
    public static void CreateNewItem()
    {
        Print("Please enter the item name:");
        string? name = Console.ReadLine();
        Print("Please enter the item price:");
        double price = Convert.ToDouble(Console.ReadLine());
        Item.Items.Add(new Item(name, price));
        Print($"***{name} successfully added***");
        ItemsListing();
    }
    
    public static void DeleteItem()
    {
        ItemsListing();
        Print("Please enter the id of the item you wish to delete");
        selection = Console.ReadLine();
        int id = Convert.ToInt32(selection);
        Item.Items.RemoveAt(id - 1);//Remove(name of the item)
        Print("***Item successfully deleted***");
        ItemsListing();
    }

    //login process
    public static async Task<string> SetupProfile()
    {
        Print("Profile setup, getting your profile ready...");
        await Task.Delay(4000);
        Print("Loading profile information from database...");
        await Task.Delay(4000);
        Print("Profile info retrieved");
        await Task.Delay(4000);
        return "Profile setup";
    }
    public static async Task<string> InitializeCart()
    {
        Print("Cart init, checking for saved cart items...");
        await Task.Delay(4000);
        Print("Initializing cart...");
        await Task.Delay(4000);
        Print("Cart details ready");
        await Task.Delay(4000);
        return "Cart details";
    }
    public static async Task<string> SetupItems()
    {
        Print("Item setup, Connecting to database...");
        await Task.Delay(4000);
        Print("Retrieving all items in stock");
        await Task.Delay(4000);
        Print("Items loaded from database");
        await Task.Delay(4000);
        return "Items in stock";
    }

    public static async Task LoginSetup()
    {
        var profileSetup = SetupProfile();
        var cartDetails = InitializeCart();
        var stockItems = SetupItems();
        
        
        var loginTasks = new List<Task> { profileSetup, cartDetails, stockItems };
        while(loginTasks.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(loginTasks);
            if (finishedTask == profileSetup)
            {
                Print("Profile is ready");
            }
            else if (finishedTask == cartDetails)
            {
                Print("Cart is ready");
            }
            else if (finishedTask == stockItems)
            {
                Print("Items are ready");
            }
            await finishedTask;
            loginTasks.Remove(finishedTask);
        }
        Print("Login Complete!");
    }


    //logOut process
    public static async Task<string> CleanProfileSetups()
    {
        Print("Profile setup, deleting your profile setups...");
        await Task.Delay(4000);
        Print("Deleting profile setups from database...");
        await Task.Delay(4000);
        Print("Profile cleaned");
        await Task.Delay(4000);
        return "Profile cleaned!";
    }
    public static async Task<string> EmptyCart()
    {
        Print("Cart empting, checking for saved cart items...");
        await Task.Delay(4000);
        Print("Deleting items from cart...");
        await Task.Delay(4000);
        Print("Cart cleaned ready");
        await Task.Delay(4000);
        return "Cart is empty!";
    }
    public static async Task<string> RestoreItemsToStock()
    {
        Print("Item restoring to stock, Connecting to database...");
        await Task.Delay(4000);
        Print("Returning all items to stock");
        await Task.Delay(4000);
        Print("Items loaded to stock database");
        await Task.Delay(4000);
        return "Items in stock!";
    }

    public static async Task LogoutSetup()
    {
        var cleanProfileSetups = CleanProfileSetups();
        var emptyCart = EmptyCart();
        var restoreItems = RestoreItemsToStock();


        var logoutTasks = new List<Task> { cleanProfileSetups, emptyCart, restoreItems };
        while (logoutTasks.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(logoutTasks);
            if (finishedTask == cleanProfileSetups)
            {
                Print("Profile cleaned!");
            }
            else if (finishedTask == emptyCart)
            {
                Print("Cart is empty!");
            }
            else if (finishedTask == restoreItems)
            {
                Print("Items restoked!");
            }
            await finishedTask;
            logoutTasks.Remove(finishedTask);
        }
        Print("LogOut Complete!");
    }


}

