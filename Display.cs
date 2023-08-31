using System;
namespace AdvancedShoppingCart;
using static Methods;

public static class Display
{
    public static void HomePage()
    {
        Print(
        "----------------Main menu-----------------\n" +
        "Hello user, welcome to our store. \n" +
        "Please select one of the following options \n " +
        "1. Register \n" +
        "2. Login\n" +
        "3. Logout\n" +
        "------------------------------------------"

        );
    }
    public static void CLoggedinPage()//customer logged in page
    {
        Print(
        "------------Customer Logged in-------------\n" +
        "Please select one of the following options: \n" +
        "0. back to previous menu\n" +
        "1. View cart\n" +
        "2. Add items to cart\n" +
        "------------------------------------------");
    }
    public static void ALoggedinPage()//admin logged in page
    {
        Print(
        "--------------Admin Logged in--------------\n" +
        "Please select one of the following options: \n" +
        "0. back to previous menu\n" +
        "1. View items\n" +
        "2. Create new item\n" +
        "3. Delete items\n" +
        "------------------------------------------");
    }
    public static void ItemsListing()
    {
        Print("-----Items in stock-----");
        foreach (Item item in Item.Items)
        {
            Print(item.ToString());
        }
        Print("------------------------");
    }
}

