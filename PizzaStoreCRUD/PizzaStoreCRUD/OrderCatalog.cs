using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class OrderCatalog
    {
        private List<Order> Orders;

        // Konstruktør for OrderCatalog klassen
        public OrderCatalog()
        {
            Orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void DeleteOrder(int orderID)
        {
            Orders.RemoveAll(o => o.OrderID == orderID);
        }

        public void UpdateOrder(int orderID, Customer newCustomer, List<Pizza> newPizzas)
        {
            Order order = Orders.FirstOrDefault(o => o.OrderID == orderID);
            if (order != null)
            {
                order.Customer = newCustomer;
                order.Pizzas = newPizzas;
            }
        }

        public Order SearchOrder(int orderID)
        {
            return Orders.FirstOrDefault(o => o.OrderID == orderID);
        }

        public void PrintOrders()
        {
            Console.WriteLine("\nAktuelle Ordrer:");
            foreach (Order order in Orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
