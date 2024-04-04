using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class MenuCatalog
    {
        private List<Pizza> Pizzas;

        // Konstruktør for MenuCatalog klassen
        public MenuCatalog()
        {
            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        public void DeletePizza(int pizzaID)
        {
            Pizzas.RemoveAll(p => p.PizzaID == pizzaID);
        }

        public void UpdatePizza(int pizzaID, string newName, string newIngredients, decimal newPrice)
        {
            Pizza pizza = Pizzas.FirstOrDefault(p => p.PizzaID == pizzaID);
            if (pizza != null)
            {
                pizza.Name = newName;
                pizza.Ingredients = newIngredients;
                pizza.Price = newPrice;
            }
        }

        public Pizza SearchPizza(int pizzaID)
        {
            return Pizzas.FirstOrDefault(p => p.PizzaID == pizzaID);
        }

        public void PrintMenu()
        {
            Console.WriteLine("\nTilgængelige pizzaer:");
            foreach (Pizza pizza in Pizzas)
            {
                Console.WriteLine(pizza);
            }
        }
    }
}
