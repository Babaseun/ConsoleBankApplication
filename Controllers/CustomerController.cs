using ConsoleBankApplication.Models;
using System;
using System.Collections.Generic;

namespace ConsoleBankApplication.Controllers
{
    internal class CustomerController
    {
        public Customer RegisterCustomer()
        {
            string name;
            string email;
            string password;
            StandardMessages.WelcomeMessage();
            Console.WriteLine("Please enter your name:");
            name = Console.ReadLine();
            Console.WriteLine("Please enter your email:");
            email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            password = Console.ReadLine();

            Customer customer = new Customer(Guid.NewGuid(), name, email, password);

            return customer;
        }

        public Dictionary<string, string> LoginCustomer()
        {
            Dictionary<string, string> loginData = new Dictionary<string, string>();
            Console.WriteLine("Please enter your email:");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            loginData["email"] = email;
            loginData["password"] = password;

            return loginData;
        }
    }
}