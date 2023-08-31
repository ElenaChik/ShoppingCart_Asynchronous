using System;
namespace AdvancedShoppingCart;

//Console shopping cart
using static Methods;
using static Display;
using static Linq;

class Program
{
 

    //1. display prompt for login/ Register/logout
    static async Task Main(string[] args)
    {
        Linq.runLinq();

        string selection;
        do
        {
            HomePage();
            selection = Console.ReadLine();

            switch (selection)
            {
                case "1"://register
                    Register();
                    //send back to login
                    break;
                case "2"://login
                    await Login();
                    break;
            }

        } while (selection != "3");//logout

        //2.During login, getting your profile ready, getting your cart initialized, getting items ready for display
        // after login,prompt user to view cart, add items to cart,
        //or logout

        //3. if view cart selected:
        //display items in their cart and prompt for check out.
        //if cart is empty, display message and take back to 2.

        //if checkout, you simply empty cart and take back to 2


        //to add items to cart, display items available, prompt for item, add item to their cart

        //if they select logout,exit the program.
    }
}

