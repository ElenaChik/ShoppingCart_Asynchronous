using System;
namespace AdvancedShoppingCart;


public class Item
{
    public static List<Item> Items = ItemList();
    public string Name { get; set; }
    public double Price { get; set; }

    public Item(string tempName, double tempPrice)
    {
        Name = tempName;
        Price = tempPrice;
    }


    public static List<Item> ItemList()
    {
        return new List<Item> {(new Item("Shoes", 20.0)),
            (new Item("ball", 30.0)),
            (new Item("plate", 10.0))};
    }

    public override string ToString() => ($"{Items.IndexOf(this) + 1}: {Name} \t {Price}$");
    
}

