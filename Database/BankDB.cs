using System;
using System.Collections.Generic;
using BankAppLib;

namespace bankapp_refactored_week4
{
    public static class BankDB
    {
        public static List<Customer> Customers { get; set; } = new List<Customer>();
        public static List<Account> Accounts { get; set; } = new List<Account>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}