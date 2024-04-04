using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    // Private felter for katalogerne over menuer, kunder og ordrer
    public class Store
    {
        private MenuCatalog menuCatalog;
        private CustomerCatalog customerCatalog;
        private OrderCatalog orderCatalog;

        // Konstruktør for Store klassen
        public Store()
        {
            menuCatalog = new MenuCatalog();
            customerCatalog = new CustomerCatalog();
            orderCatalog = new OrderCatalog();
        }

        // Metoden Run starter hovedmenuen og behandler brugerinteraktion
        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nVelkommen Til Big Mamma Pizzarias Opdateret System!");
                Console.WriteLine("1. Tilføj en ny pizza.");
                Console.WriteLine("2. Slet en pizza.");
                Console.WriteLine("3. Opdatere en pizza.");
                Console.WriteLine("4. Hvis alle pizzaer.");
                Console.WriteLine("5. Tilføj en ny kunde.");
                Console.WriteLine("6. Slet en kunde.");
                Console.WriteLine("7. Opdatere en kunde.");
                Console.WriteLine("8. Hvis alle kunder.");
                Console.WriteLine("9. Tilføj en ny ordre.");
                Console.WriteLine("10. Slet en ordre.");
                Console.WriteLine("11. Opdatere en ordre.");
                Console.WriteLine("12. Hvis alle ordre.");
                Console.WriteLine("13. Forlad programmet.");

                Console.Write("Vælg en mulighed: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddNewPizza();
                        break;
                    case 2:
                        DeletePizza();
                        break;
                    case 3:
                        UpdatePizza();
                        break;
                    case 4:
                        ListPizzas();
                        break;
                    case 5:
                        AddNewCustomer();
                        break;
                    case 6:
                        DeleteCustomer();
                        break;
                    case 7:
                        UpdateCustomer();
                        break;
                    case 8:
                        ListCustomers();
                        break;
                    case 9:
                        AddNewOrder();
                        break;
                    case 10:
                        DeleteOrder();
                        break;
                    case 11:
                        UpdateOrder();
                        break;
                    case 12:
                        ListOrders();
                        break;
                    case 13:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig valgmulighed. Prøv venligst igen.");
                        break;

                }
            }
        }

        private void AddNewPizza()
        {
            Console.Write("Indtast Pizza ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Pizza Navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast Ingredienser: ");
            string ingredients = Console.ReadLine();
            Console.Write("Indtast Pris: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Pizza pizza = new Pizza(id, name, ingredients, price);
            menuCatalog.AddPizza(pizza);
        }

        private void DeletePizza()
        {
            Console.Write("Indtast Pizza ID For At Slette: ");
            int id = Convert.ToInt32(Console.ReadLine());
            menuCatalog.DeletePizza(id);
        }

        private void UpdatePizza()
        {
            Console.Write("Indtast Pizza ID For At Opdatere: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Ny Navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast Nye Ingredienser: ");
            string ingredients = Console.ReadLine();
            Console.Write("Indtast Nye Pris: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            menuCatalog.UpdatePizza(id, name, ingredients, price);
        }

        private void ListPizzas()
        {
            menuCatalog.PrintMenu();
        }

        private void AddNewCustomer()
        {
            Console.Write("Indtast Kunde ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Kundenavn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast Adresse: ");
            string address = Console.ReadLine();
            Console.Write("Indtast Telefonnummer: ");
            string phoneNumber = Console.ReadLine();

            Customer customer = new Customer(id, name, address, phoneNumber);
            customerCatalog.AddCustomer(customer);
        }

        private void DeleteCustomer()
        {
            Console.Write("Indtast Kunde ID For At Slette: ");
            int id = Convert.ToInt32(Console.ReadLine());
            customerCatalog.DeleteCustomer(id);
        }

        private void UpdateCustomer()
        {
            Console.Write("Indtast Kunde ID For At Opdatere: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Nyt Navn: ");
            string name = Console.ReadLine();
            Console.Write("Indtast Ny Adresse: ");
            string address = Console.ReadLine();
            Console.Write("Indtast Nyt Telefonnummer: ");
            string phoneNumber = Console.ReadLine();

            customerCatalog.UpdateCustomer(id, name, address, phoneNumber);
        }

        private void ListCustomers()
        {
            customerCatalog.PrintCustomers();
        }

        private void AddNewOrder()
        {
            Console.Write("Indtast Ordre ID: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Kunde ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Customer customer = customerCatalog.SearchCustomerByName(customerId.ToString());
            if (customer == null)
            {
                Console.WriteLine("Kunde ikke fundet!");
                return;
            }

            Order order = new Order(orderId, customer);

            bool addingPizzas = true;
            while (addingPizzas)
            {
                Console.Write("Indtast Pizza ID For At Tilføje (eller \"færdig\" For At Afslutte): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "færdig")
                {
                    addingPizzas = false;
                }
                else
                {
                    int pizzaId = Convert.ToInt32(input);
                    Pizza pizza = menuCatalog.SearchPizza(pizzaId);
                    if (pizza != null)
                    {
                        order.AddPizza(pizza);
                    }
                    else
                    {
                        Console.WriteLine("Pizza ikke fundet!");
                    }
                }
            }

            orderCatalog.AddOrder(order);
        }

        private void DeleteOrder()
        {
            Console.Write("Indtast Ordre ID For At Slette: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            orderCatalog.DeleteOrder(orderId);
        }

        private void UpdateOrder()
        {
            Console.Write(" Indtast nye Ordre ID For At Opdatere: ");
            int orderId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Indtast Nye Kunde ID: ");
            int newCustomerId = Convert.ToInt32(Console.ReadLine());

            Customer newCustomer = customerCatalog.SearchCustomerByName(newCustomerId.ToString());
            if (newCustomer == null)
            {
                Console.WriteLine("Kunde ikke fundet!");
                return;
            }

            List<Pizza> newPizzas = new List<Pizza>();
            bool addingPizzas = true;
            while (addingPizzas)
            {
                Console.Write("Indtast Pizza ID For At Tilføje (Eller \"færdig\" For At Afslutte): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "færdig")
                {
                    addingPizzas = false;
                }
                else
                {
                    int pizzaId = Convert.ToInt32(input);
                    Pizza pizza = menuCatalog.SearchPizza(pizzaId);
                    if (pizza != null)
                    {
                        newPizzas.Add(pizza);
                    }
                    else
                    {
                        Console.WriteLine("Pizza ikke fundet!");
                    }
                }
            }

            orderCatalog.UpdateOrder(orderId, newCustomer, newPizzas);
        }

        private void ListOrders()
        {
            orderCatalog.PrintOrders();
        }
    }
}
