using System;
namespace AdvancedShoppingCart;

public class Admin:User
{
	public Admin()
	{
	}
    public Admin(string uname, string pwd)
    {
        Username = uname;
        Password = pwd;
        Isadmin = true;
    }
    public Admin(User temp)
    {
        Username = temp.Username;
        Password = temp.Password;
        Isadmin = temp.Isadmin;
        
    }
    public override string ToString()//convert to lambda
    {
        return ($"Admin {Username}");
    }
}

