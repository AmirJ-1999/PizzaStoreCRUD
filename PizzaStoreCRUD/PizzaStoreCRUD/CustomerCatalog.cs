using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class CustomerCatalog
    {
        private List<Customer> Customers;

        // Konstruktør for CustomerCatalog klassen
        public CustomerCatalog()
        {
            Customers = new List<Customer>();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void DeleteCustomer(int customerID)
        {
            Customers.RemoveAll(c => c.CustomerID == customerID);
        }

        public void UpdateCustomer(int customerID, string newName, string newAddress, string newPhoneNumber)
        {
            Customer customer = Customers.FirstOrDefault(c => c.CustomerID == customerID);
            if (customer != null)
            {
                customer.Name = newName;
                customer.Address = newAddress;
                customer.PhoneNumber = newPhoneNumber;
            }
        }

        public Customer SearchCustomerByName(string name)
        {
            return Customers.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void PrintCustomers()
        {
            Console.WriteLine("\nRegisteret kunder:");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
