using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace AdvancedShoppingCart;
using static Methods;

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool Isadmin { get; set; }
    public List<Item> CartItems { get; set; }
    public static List<User> Users = CreateUsers();

    //default constructor
    public User() { }

    public User(string uname, string pwd)
    {
        Username = uname;
        Password = pwd;
        CartItems = new List<Item>();
    }

    public override string ToString()
    {
        return ($"{Username}");
    }

    public static List<User> CreateUsers()
    {
        return new List<User> {(new Admin("Chrysa", "1234")),
            (new Customer("Jack", "5678")),
            (new Customer("Jill", "9012"))};
    }

    public bool compareUser(User temp)//convert to lambda expression
    {
        return Username == temp.Username && Password == temp.Password;
    }

    //Func<User,User, bool> compareUser = (user1,temp) => user1.Username == temp.Username && user1.Password == temp.Password;
}

