using BankAppLib;
using System;
using System.Collections.Generic;

namespace bankapp_refactored_week4.Controllers
{
    internal class AccountController
    {
        public static int accountNumberGenerator = 1234567890;
        public string accountNumber { get; set; }

        public AccountController()
        {
            this.accountNumber = accountNumberGenerator.ToString();
            accountNumberGenerator++;
        }

        public Account CreateAccount(Guid ID)
        {
            Console.WriteLine("Enter savings or current account ?");

            string accountType = Console.ReadLine();
            Console.WriteLine("dollar or naria account ?");
            string note = Console.ReadLine();

            Account newAccount = new Account();

            newAccount.ID = Guid.NewGuid();
            newAccount.AccountType = accountType;
            newAccount.Balance = 0.0M;
            newAccount.OwnerID = ID;
            newAccount.AccountNumber = accountNumber;
            newAccount.Note = note;
            newAccount.DateCreated = DateTime.Now;

            return newAccount;
        }

        public Account GetAccount(string accountNumber)
        {
            return BankDB.Accounts.Find(acc => acc.AccountNumber == accountNumber);
        }

        public Account UpdateAccount(string accountNumber, decimal amt)
        {
            var account = BankDB.Accounts.Find(acc => acc.AccountNumber == accountNumber);
            account.Balance += amt;

            return account;
        }

        public List<Account> AccountsForTransFar(string accountNumber, string transferAccount)
        {
            var firstAccount = BankDB.Accounts.Find(acc => acc.AccountNumber == accountNumber);
            var secondAccount = BankDB.Accounts.Find(acc => acc.AccountNumber == transferAccount);

            return new List<Account>() { firstAccount, secondAccount };
        }

        public Account UpdateAccountOnWithDraw(string accountNumber, decimal amt)
        {
            var account = BankDB.Accounts.Find(acc => acc.AccountNumber == accountNumber);
            account.Balance -= amt;

            return account;
        }
    }
}