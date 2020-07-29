using System;

namespace ConsoleBankApplication.Models
{
    internal class Transactions
    {
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
        public int Note { get; set; }
        public DateTime Date { get; set; }
    }
}