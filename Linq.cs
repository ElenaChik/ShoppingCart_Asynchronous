using System.Linq;
namespace AdvancedShoppingCart;

public class Linq
{
    public static void runLinq()
    {

        string[] digits = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        // Query syntax
        var lowNumsQ = from res in digits where res.Length < Array.IndexOf(digits, res) select res;

        foreach (string res in lowNumsQ)
            Console.WriteLine("length " + res.Length + " < index " + Array.IndexOf(digits, res) + " is " + res);



        //Method syntax
        //retrieve all elements with length less than the index

        var lowNums = digits.Where((temp, index) => temp.Length == index);

        //print the result
        foreach (string res in lowNums)
            Console.WriteLine("length == index " + res);

        /*
        // LINQ
   //1.
       int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7 };
       List<int> list = new List<int>();

       var lowNums1 = from temp in numbers where temp < 5 select temp ;

       foreach (int res in lowNums1)
           Console.WriteLine("1: " + res);
       Console.WriteLine("------------");

       //2.
       var lowNum2 = numbers.Where(temp => temp < 5);

       foreach (int res in lowNum2)
           Console.WriteLine("2: " + res);
       Console.WriteLine("------------");

       //3.
       string[] digits = { "Zero", "One", "Two", "Thr" , "Four"};

       // to return only those that the str.lenth == index in digits[index]
       var lowNums3 = digits.Where((temp, index) => temp.Length == index);

       foreach (string res in lowNums3)
           Console.WriteLine("3: " + res);
       Console.WriteLine("------------");

       */

    }
}