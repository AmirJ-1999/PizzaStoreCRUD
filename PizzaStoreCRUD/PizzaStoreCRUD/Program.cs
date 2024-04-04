using PizzaStoreCRUD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStoreCRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Store store = new Store();
                store.Run(); // Kalder "Run" og starter programmet.

                Console.WriteLine("Lavet af Amir Jawad.");
                Console.ReadKey();
            }
        }
    }
}

