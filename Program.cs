using BankAppLib;
using bankapp_refactored_week4.Controllers;
using bankapp_refactored_week4.Helpers;
using System;

namespace bankapp_refactored_week4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program.StartApplication();
        }

        public static void StartApplication()
        {
            CustomerSession session = new CustomerSession();

            while (true)
            {
            START:

                StandardMessages.WelcomeMessage();

                string option = Console.ReadLine();

                if (option == "1")
                {
                    CustomerController customer = new CustomerController();
                    var responseData = customer.RegisterCustomer();

                    if (Auth.CheckIfUserExists(responseData) == false)
                    {
                        BankDB.Customers.Add(responseData);
                        session.ID = responseData.ID;
                        session.Name = responseData.Name;
                        session.Email = responseData.Email;
                    }
                    else
                    {
                        StandardMessages.BadRequestMessageForUser(responseData.Name);
                        goto START;
                    }
                }
                if (option == "2")
                {
                    CustomerController customer = new CustomerController();
                    var responseData = customer.LoginCustomer();

                    if (Auth.CheckIfUserExists(responseData) == true)
                    {
                        session.ID = responseData.ID;
                        session.Name = responseData.Name;
                        session.Email = responseData.Email;
                    }
                    else
                    {
                        StandardMessages.BadRequestMessageForUser(responseData.Name);
                        goto START;
                    }
                }
                while (session.ID != null)
                {
                OPTIONS:
                    StandardMessages.AccountOptions();
                    string accOption = Console.ReadLine();

                    if (accOption == "1")
                    {
                        AccountController account = new AccountController();
                        var newAccount = account.CreateAccount(session.ID);
                        BankDB.Accounts.Add(newAccount);
                        StandardMessages.AccountInfo(newAccount);
                        goto OPTIONS;
                    }
                    if (accOption == "2")
                    {
                        AccountController account = new AccountController();

                        var accountNo = StandardMessages.EnterAccountMessage();
                        var getAccount = account.GetAccount(accountNo);
                        StandardMessages.AccountInfo(getAccount);

                        var amt = StandardMessages.AmountToDeposit();
                        var updateAcc = account.UpdateAccount(accountNo, amt);
                        StandardMessages.AccountInfo(updateAcc);

                        var transaction = new Transaction();
                        transaction.FullName = session.Name;
                        transaction.AccountNumber = getAccount.AccountNumber;
                        transaction.AccountType = getAccount.AccountType;
                        transaction.Balance = getAccount.Balance;
                        transaction.Amount = amt;
                        transaction.Date = DateTime.Now;
                        transaction.Note = getAccount.Note;
                        transaction.OwnerID = session.ID;

                        BankDB.Transactions.Add(transaction);

                        goto OPTIONS;
                    }
                    if (accOption == "3")
                    {
                        AccountController account = new AccountController();

                        var firstAccountNumber = StandardMessages.EnterAccountMessage();
                        var secondAccountNumber = StandardMessages.EnterAccountMessage();

                        var getFirstAccount = account.GetAccount(firstAccountNumber);
                        var getSecondAccount = account.GetAccount(secondAccountNumber);

                        var amt = StandardMessages.TransferMessage();

                        if (getFirstAccount == null || getSecondAccount == null)
                        {
                            Console.WriteLine("Please Check account numbers and try again");
                            goto OPTIONS;
                        }
                        if (getFirstAccount.AccountType == "savings")
                        {
                            if (getFirstAccount.Balance < 100 || amt == getFirstAccount.Balance)
                            {
                                Console.WriteLine("insufficient");
                                goto OPTIONS;
                            }
                        }
                        if (getFirstAccount.AccountType == "current")
                        {
                            if (getFirstAccount.Balance < 1000 || amt == getFirstAccount.Balance)
                            {
                                Console.WriteLine("insufficient");
                                goto OPTIONS;
                            }
                        }

                        StandardMessages.AccountInfo(getFirstAccount);
                        StandardMessages.AccountInfo(getSecondAccount);

                        var accounts = account.AccountsForTransFar(firstAccountNumber, secondAccountNumber);

                        var acc1 = accounts[0];
                        var acc2 = accounts[1];
                        acc1.Balance = acc1.Balance - amt;
                        acc2.Balance = acc2.Balance + amt;

                        StandardMessages.AccountInfo(getFirstAccount);
                        StandardMessages.AccountInfo(getSecondAccount);

                        var transaction = new Transaction();
                        transaction.FullName = session.Name;
                        transaction.AccountNumber = getFirstAccount.AccountNumber;
                        transaction.AccountType = getFirstAccount.AccountType;
                        transaction.Balance = getFirstAccount.Balance;
                        transaction.Amount = amt;
                        transaction.Date = DateTime.Now;
                        transaction.Note = getFirstAccount.Note;
                        transaction.OwnerID = session.ID;

                        BankDB.Transactions.Add(transaction);
                        goto OPTIONS;
                    }
                    if (accOption == "5")
                    {
                        AccountController account = new AccountController();

                        var accountNo = StandardMessages.EnterAccountMessage();
                        var getAccount = account.GetAccount(accountNo);
                        var amt = StandardMessages.TransferMessage();

                        if (getAccount == null)
                        {
                            Console.WriteLine("Please Check account numbers and try again");
                            goto OPTIONS;
                        }
                        if (getAccount.AccountType == "savings")
                        {
                            if (getAccount.Balance < 100 || amt == getAccount.Balance)
                            {
                                Console.WriteLine("insufficient");
                                goto OPTIONS;
                            }
                        }
                        if (getAccount.AccountType == "current")
                        {
                            if (getAccount.Balance < 1000 || amt == getAccount.Balance)
                            {
                                Console.WriteLine("insufficient");
                                goto OPTIONS;
                            }
                        }

                        var updatedAccount = account.UpdateAccountOnWithDraw(getAccount.AccountNumber, amt);

                        StandardMessages.AccountInfo(updatedAccount);
                        var transaction = new Transaction();
                        transaction.FullName = session.Name;
                        transaction.AccountNumber = getAccount.AccountNumber;
                        transaction.AccountType = getAccount.AccountType;
                        transaction.Balance = getAccount.Balance;
                        transaction.Amount = amt;
                        transaction.Date = DateTime.Now;
                        transaction.Note = getAccount.Note;
                        transaction.OwnerID = session.ID;

                        BankDB.Transactions.Add(transaction);
                        goto OPTIONS;
                    }
                    if (accOption == "6")
                    {
                        StandardMessages.ListOfTransactions(session.ID);
                    }
                    if (accOption == "4")
                    {
                        Program.StartApplication();
                    }
                }
            }
        }
    }
}