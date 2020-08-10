using System;
using System.Collections.Generic;
using BankAppLib;

namespace bankapp_refactored_week4.Helpers
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