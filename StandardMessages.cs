using ConsoleBankApplication.Models;
using System;
using System.Collections.Generic;

namespace ConsoleBankApplication
{
    internal class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("---------Welcome to ConsoleBankApplication -----");
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

        public static void ListOfAccounts(List<Account> accounts)
        {
            Console.WriteLine("------List Of Accounts-----");
            foreach (var account in accounts)
            {
                Console.WriteLine();
                Console.WriteLine("AccountID: " + account.ID);
                Console.WriteLine("AccountType: " + account.AccountType);
                Console.WriteLine("AccountNumber: " + account.AccountNumber);
                Console.WriteLine("Balance: " + account.Balance);
                Console.WriteLine("CreatedAT: " + account.DateCreated);
                Console.WriteLine("Currency: " + account.Note);
                Console.WriteLine("OwnerID: " + account.OwnerID);
            }
        }

        public static void DepositMessage()
        {
            Console.WriteLine("------Do you want to credit an account--y/n---");
        }

        public static void EnterAccountMessage()
        {
            Console.WriteLine("------Enter your account number-----");
        }

        public static void CreditMessage()
        {
            Console.WriteLine("------Account has been credited-----");
        }

        public static string AmountToDeposit()
        {
            Console.WriteLine("------How much do you want to deposit ?------");
            string amount = Console.ReadLine();
            Console.WriteLine();
            return amount;
        }

        public static string AmountToWithdraw()
        {
            Console.WriteLine("------How much do you want to withdraw ?------");
            string amount = Console.ReadLine();
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

        public static void TransferMessage()
        {
            Console.WriteLine("Do you want to transfer from an account to another account---y/n--");
        }

        public static void TransactionData(List<Transactions> transactions, Guid ID, string name)
        {
            //var getTransaction = transactions.Find(transaction => transaction.)
        }
    }
}