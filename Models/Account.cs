using System;

namespace ConsoleBankApplication.Models
{
    internal class Account
    {
        public Guid ID { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public Guid OwnerID { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
    }
}