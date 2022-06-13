using System;

namespace ConsoleUI
{
    public class ConsoleUI : IUI
    {
        public void Clear()
        {
            Console.Clear();
        }

        public string GetString()
        {
            return Console.ReadLine();
        } 
        
        public string GetKey()
        {
            return Console.ReadKey(intercept: true).KeyChar.ToString();
        }

        public void Meny(bool isFull, string options, string menyheading)
        {
            Console.WriteLine(isFull ? "No spots left" : menyheading + "\n" + options);
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowMeny()
        {
            Console.WriteLine("1, Park");
            Console.WriteLine("2, List Parked");
            Console.WriteLine("3, List By Type");
            Console.WriteLine("4, UnPark");
            Console.WriteLine("5, Search");
            Console.WriteLine("6, Seed Vehicles");
            Console.WriteLine("0, Quit");
        }
    }
}
