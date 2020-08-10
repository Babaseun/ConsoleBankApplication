using BankAppLib;
using ConsoleBankApplication.Helpers;
using System;

namespace ConsoleBankApplication.Controllers
{
    public class CustomerController
    {
        public Customer RegisterCustomer()
        {
            string name;
            string email;
            string password;
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your email:");
            email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            password = Console.ReadLine();

            Customer customer = new Customer(name, email, password);

            return customer;
        }

        public Customer LoginCustomer()
        {
            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();
            var customer = BankDB.Customers.Find(customer => customer.Email == email);

            return customer;
        }
    }
}