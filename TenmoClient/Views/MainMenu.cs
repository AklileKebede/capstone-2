using MenuFramework;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.DAL;
using TenmoClient.Data;

namespace TenmoClient.Views
{
    public class MainMenu : ConsoleMenu
    {

        // TODO: INITILIZAE DAO'S HERE, AND SET THEM IN THE CONSTRUCTOR
        private IAccountDAO accountDao;
        
        public MainMenu(IAccountDAO accountDao)
        {
            this.accountDao = accountDao;

            // TODO: NEED TO UPDATE THE CONSTRUCTOR TO HAVE THE DAO'S PASSED IN, AND SET THEM IN THE CONSTRUCTOR
            AddOption("View your current balance", ViewBalance)
                .AddOption("View your past transfers", ViewTransfers)
                .AddOption("View your pending requests", ViewRequests)
                .AddOption("Send TE bucks", SendTEBucks)
                .AddOption("Request TE bucks", RequestTEBucks)
                .AddOption("Log in as different user", Logout)
                .AddOption("Exit", Exit);
        }

        protected override void OnBeforeShow()
        {
            Console.WriteLine($"TE Account Menu for User: {UserService.GetUserName()}");
        }

        private MenuOptionResult ViewBalance()
        {
            try { 
            // create a rest request to the /users/username/account# url, get back a balance
            int accountId = MainMenu.GetInteger("Please enter your account Id: ");

                // TODO: THIS WILL CALL THE ACCOUNTDAO AND IT WILL RETURN AN ACCOUNT (GETACCOUNT METHOD).  WE WILL USE THAT ACCOUNT TO REFERENCE THE BALANCE BY ACCOUNT.BALANCE
                // UserService.GetUserName
               // Account account = accountDao.GetAccount(accountId);
                Account account1 = accountDao.GetAccount(UserService.GetUserName(), accountId);
                Console.WriteLine($"Your account {accountId} has the balance of: {account1.Balance}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ViewTransfers()
        {
            Console.WriteLine("Not yet implemented!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult ViewRequests()
        {
            Console.WriteLine("Not yet implemented!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult SendTEBucks()
        {
            Console.WriteLine("Not yet implemented!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult RequestTEBucks()
        {
            Console.WriteLine("Not yet implemented!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Logout()
        {
            UserService.SetLogin(new API_User()); //wipe out previous login info
            return MenuOptionResult.CloseMenuAfterSelection;
        }

    }
}
