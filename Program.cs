using ConsoleBankApplication.Controllers;
using ConsoleBankApplication.Helpers;
using System;

namespace ConsoleBankApplication
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
                        var customerAccount = account.CreateAccount(session.ID);
                        StandardMessages.AccountInfo(customerAccount);
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

                        goto OPTIONS;
                    }
                }
            }
        }
    }
}