using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace AdvancedShoppingCart;
using static Methods;

public class Customer:User
{
    public Customer(string uname, string pwd)
	{
        Username = uname;
        Password = pwd;
        Isadmin = false;
        CartItems = new List<Item>();
    }
    public Customer(User temp)
    {
        Username = temp.Username;
        Password = temp.Password;
        Isadmin = temp.Isadmin;
        CartItems = temp.CartItems;
    }
    public void DisplayCart()
    {
        Print("-----------Cart Items-------------");
        if (CartItems.Count == 0)
        {
            Print("Cart is empty");
            return;
        }
        foreach (Item item in CartItems)
        {
            Print(item.ToString());
        }
    }

    public void AddItems(Item temp)
    {
        CartItems.Add(temp);
    }

    public void Checkout()
    {
        CartItems.Clear();
        Print("Check out succcessful");
        DisplayCart();
    }

    public override string ToString()//convert to lambda
    {
        return ($"Customer {Username}");
    }

}

