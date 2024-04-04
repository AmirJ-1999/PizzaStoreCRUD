using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStoreCRUD
{
    public class Customer
    {
        // Egenskaber for Customer-klassen
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // Konstruktør for Customer-klassen
        public Customer(int customerID, string name, string address, string phoneNumber)
        {
            CustomerID = customerID;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"{CustomerID}: {Name}, {Address}, {PhoneNumber}";
        }
    }
}
