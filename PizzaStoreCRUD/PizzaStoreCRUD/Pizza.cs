using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class Pizza
    {
        // Egenskaber for Pizza-klassen
        public int PizzaID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }

        // Konstruktør for Pizza-klassen
        public Pizza(int pizzaID, string name, string ingredients, decimal price)
        {
            PizzaID = pizzaID;
            Name = name;
            Ingredients = ingredients;
            Price = price;
        }

        public override string ToString()
        {
            return $"{PizzaID}: {Name} - {Ingredients} - {Price} kr.";
        }
    }
}