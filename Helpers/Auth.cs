using System;
using System.Collections.Generic;
using BankAppLib;

namespace ConsoleBankApplication.Helpers
{
    public class Auth
    {
        public static bool CheckIfUserExists(Customer customer)
        {
            var user = BankDB.Customers.Find(customer => customer.Email == customer.Email);

            if (user == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}