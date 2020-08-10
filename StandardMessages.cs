using BankAppLib;
using System;
using System.Collections.Generic;

namespace bankapp_refactored_week4
{
    internal class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("---------Welcome to ConsoleBankApplication -----");
            Console.WriteLine("---------Press 1 to register 2 to login  -----");

            Console.WriteLine();
        }

        public static void BadRequestMessageForUser(string name)
        {
            Console.WriteLine("User " + name + " already registered");
            Console.WriteLine("-----Please Login to continue----");
            Console.WriteLine();
        }

        public static void BadRequestMessageForUser2(string email)
        {
            Console.WriteLine("User with these" + email + "  is not registered");
            Console.WriteLine("-----Please Sign up to continue----");
            Console.WriteLine();
        }

        public static void CreateAccountMsg()
        {
            Console.WriteLine();

            Console.WriteLine("------Create a Bank Account------");
            Console.WriteLine();
        }

        public static void SuccessMessage()
        {
            Console.WriteLine("---------Registeration Successful--------");
        }

        public static void AccountInfo(Account account)
        {
            Console.WriteLine("------Account Information-----");
            Console.WriteLine();
            Console.WriteLine("AccountID: " + account.ID);
            Console.WriteLine("AccountType: " + account.AccountType);
            Console.WriteLine("AccountNumber: " + account.AccountNumber);
            Console.WriteLine("Balance: " + account.Balance);
            Console.WriteLine("CreatedAT: " + account.DateCreated);
            Console.WriteLine("Currency: " + account.Note);
            Console.WriteLine("OwnerID: " + account.OwnerID);
        }

        public static void ListOfTransactions(Guid ID)
        {
            var transactions = BankDB.Transactions.FindAll(tr => tr.OwnerID == ID);
            Console.WriteLine("------Transaction History-----");

            foreach (var transaction in transactions)
            {
                Console.WriteLine();
                Console.WriteLine("Fullname: " + transaction.FullName);
                Console.WriteLine("AccountType: " + transaction.AccountType);
                Console.WriteLine("AccountNumber: " + transaction.AccountNumber);
                Console.WriteLine("Balance: " + transaction.Balance);
                Console.WriteLine("CreatedAT: " + transaction.Date);
                Console.WriteLine("Currency: " + transaction.Note);
                Console.WriteLine("Amount: " + transaction.Amount);
            }
        }

        public static void DepositMessage()
        {
            Console.WriteLine("------Do you want to credit an account--y/n---");
        }

        public static string EnterAccountMessage()
        {
            Console.WriteLine("------Enter your account number-----");
            string accountNo = Console.ReadLine();
            return accountNo;
        }

        public static void CreditMessage()
        {
            Console.WriteLine("------Account has been credited-----");
        }

        public static decimal AmountToDeposit()
        {
            Console.WriteLine("------How much do you want to deposit ?------");
            var amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            return amount;
        }

        public static decimal AmountToWithdraw()
        {
            Console.WriteLine("------How much do you want to withdraw ?------");
            var amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            return amount;
        }

        public static void WithdrawalMessage()
        {
            Console.WriteLine();
            Console.WriteLine("------Do you want to withdraw from an account---y/n--");
        }

        public static void LogOutMessage()
        {
            Console.WriteLine();
            Console.WriteLine("------Do you want to logout account---y/n--");
        }

        public static void InsufficientMessage()
        {
            Console.WriteLine();
            Console.WriteLine("------Insufficient funds---------");
        }

        public static void SuccessfulWithdrawal()
        {
            Console.WriteLine();
            Console.WriteLine("------Credit successful-----");
            Console.WriteLine();
        }

        public static decimal TransferMessage()
        {
            Console.WriteLine("How much do you want to transfer");
            var amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            return amount;
        }

        public static void AccountOptions()
        {
            Console.WriteLine("-------------Press 1 to create an account------");
            Console.WriteLine("-------------Press 2 to deposit into an account------");
            Console.WriteLine("-------------Press 3 to transfer an account------");
            Console.WriteLine("-------------Press 4 to LOGOUT------------------");
            Console.WriteLine("-------------Press 5 to Withdraw from an account------------------");
            Console.WriteLine("-------------Press 6 to see transaction HISTORY------------------");
        }
    }
}