using ConsoleBankApplication.Controllers;
using ConsoleBankApplication.Models;
using System;
using System.Collections.Generic;

namespace ConsoleBankApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Program.StartApplication();
        }

        public static void StartApplication()
        {
            List<Customer> customers = new List<Customer>(); // stores a list of customers
            List<Account> accounts = new List<Account>();  /// stores a list of accounts
            List<Transactions> allTransactions = new List<Transactions>();  /// stores a list of all transactions

            Guid ID;
            string yOrNo;
            string accountNumber;
            string transferTo;

            string amt;
            bool loggedIn = false;

            while (true)
            {
                CustomerController postCustomer = new CustomerController();
                var resForNewUser = postCustomer.RegisterCustomer();

                var getCustomer = customers.Find(customer => customer.Name == resForNewUser.Name && customer.Email == resForNewUser.Email);
                if (getCustomer == null)
                {
                    loggedIn = true;
                    customers.Add(resForNewUser);
                    ID = resForNewUser.ID;
                    StandardMessages.SuccessMessage();

                    StandardMessages.CreateAccountMsg();

                    var newAccount = new AccountController();
                    var account = newAccount.CreateAccount(ID);

                    StandardMessages.AccountInfo(account);

                    accounts.Add(account);
                }
                else
                {
                    StandardMessages.BadRequestMessageForUser(resForNewUser.Name);
                    CustomerController loginCustomer = new CustomerController();
                    var resForUser = loginCustomer.LoginCustomer();

                    var user = customers.Find(customer => customer.Email == resForUser["email"]);
                    if (user == null)
                    {
                        StandardMessages.BadRequestMessageForUser2(resForUser["email"]);
                    }
                    else
                    {
                        loggedIn = true;

                        ID = user.ID;
                        StandardMessages.SuccessMessage();

                        StandardMessages.CreateAccountMsg();

                        var newAccount = new AccountController();
                        var account = newAccount.CreateAccount(ID);

                        StandardMessages.AccountInfo(account);

                        accounts.Add(account);
                    }
                }
            Deposit:
                StandardMessages.DepositMessage();

                yOrNo = Console.ReadLine();

                if (yOrNo == "y")
                {
                    StandardMessages.EnterAccountMessage();
                    accountNumber = Console.ReadLine();

                    AccountController account = new AccountController();
                    var response = account.GetAccount(accounts, accountNumber);

                    StandardMessages.AccountInfo(response);

                    amt = StandardMessages.AmountToDeposit();

                    account.UpdateAccount(accounts, accountNumber, decimal.Parse(amt));
                    StandardMessages.CreditMessage();

                    StandardMessages.AccountInfo(response);

                    Transactions newTransaction = new Transactions();
                    //newTransaction.F
                }
                yOrNo = "";

                StandardMessages.WithdrawalMessage();
                yOrNo = Console.ReadLine();
                if (yOrNo == "y")
                {
                    StandardMessages.EnterAccountMessage();
                    accountNumber = Console.ReadLine();
                    AccountController account = new AccountController();
                    amt = StandardMessages.AmountToWithdraw();
                    var response = account.GetAccount(accounts, accountNumber);
                    if (response.AccountType.ToLower() == "savings")
                    {
                        if (response.Balance < 100)
                        {
                            StandardMessages.InsufficientMessage();
                        }
                        else
                        {
                            response.Balance = response.Balance - decimal.Parse(amt);
                            StandardMessages.SuccessfulWithdrawal();
                            StandardMessages.AccountInfo(response);
                        }
                    }
                    else
                    {
                        if (response.Balance < 1000)
                        {
                            StandardMessages.InsufficientMessage();
                        }
                        else
                        {
                            response.Balance = response.Balance - decimal.Parse(amt);
                            StandardMessages.SuccessfulWithdrawal();
                            StandardMessages.AccountInfo(response);
                        }
                    }
                }
                yOrNo = "";

                StandardMessages.TransferMessage();
                yOrNo = Console.ReadLine();
                if (yOrNo == "y")
                {
                    StandardMessages.EnterAccountMessage();
                    accountNumber = Console.ReadLine();
                    Console.WriteLine("Enter beneficiary");
                    transferTo = Console.ReadLine();
                    Console.WriteLine("Enter amount");
                    amt = Console.ReadLine();
                    AccountController account = new AccountController();
                    var firstAcc = account.GetAccount(accounts, accountNumber);
                    var secondAcc = account.GetAccount(accounts, transferTo);

                    firstAcc.Balance = firstAcc.Balance - decimal.Parse(amt);
                    secondAcc.Balance += decimal.Parse(amt);
                }
                yOrNo = "";

                Console.WriteLine("Do you want to get your transaction history y/n");
                yOrNo = Console.ReadLine();
                if (yOrNo == "y")
                {
                }

                if (loggedIn == true)
                {
                    StandardMessages.LogOutMessage();
                    yOrNo = Console.ReadLine();
                    if (yOrNo == "n")
                    {
                        goto Deposit;
                    }
                    else
                    {
                        loggedIn = false;
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You are logged out....");
                    }
                }
            }
        }
    }
}