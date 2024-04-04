using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public Customer Customer { get; set; }

        // Konstruktør for Order-klassen
        public Order(int orderID, Customer customer)
        {
            OrderID = orderID;
            Customer = customer;
            Pizzas = new List<Pizza>();
        }

        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }

        public decimal CalculateTotalPrice()
        {
            return Pizzas.Sum(pizza => pizza.Price);
        }

        public override string ToString()
        {
            IEnumerable<string> pizzaDescriptions = Pizzas.Select(p => p.ToString());
            return $"Ordre ID: {OrderID} For {Customer.Name}\nPizzaer: {string.Join(", ", pizzaDescriptions)}\nTotal Pris: kr.{CalculateTotalPrice()}";
        }
    }
}
