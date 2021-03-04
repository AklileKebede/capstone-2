using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;
using TenmoServer.Models;

namespace TenmoServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : ControllerBase
    {
        private IAccountDAO AccountDAO;
        private IUserDAO UserDAO;

        public UsersController(IAccountDAO accountDAO, IUserDAO userDAO)
        {
            this.AccountDAO = accountDAO;
            this.UserDAO = userDAO;
        }

        [HttpGet]
        //admin
    //    [Authorize(Roles = "Admin")]
        public List<User> GetUsers()
        {
            return UserDAO.GetUsers();
        }


        [HttpGet("{username}/accounts")]
      //  [Authorize(Roles = "User, Admin")]
        public ActionResult<List<Account>> GetAccountsByUsername(string username)
        {
            // todo if it they don't have access, return an empty list IF WE WANT
            if (username.ToLower() != User.Identity.Name && !User.IsInRole("Admin")) // <- this is magic
            {
                return NotFound();
            }
            List<Account> accounts = AccountDAO.GetAccounts(username);
            if(accounts == null)
            {
               return NotFound();
            }
            return accounts;
        }

        [HttpGet("{username}/accounts/{accountId}")]
        //[Authorize(Roles = "User, Admin")]
        public ActionResult<Account> GetAccountInfo(string username, int accountId)
        {
            if (username.ToLower() != User.Identity.Name && !User.IsInRole("Admin")) // <- this is magic
            {
                return NotFound();
            }
            Account userAccount = AccountDAO.GetAccount(username, accountId);
            if (userAccount == null)
            {
                return NotFound();
            }
            return userAccount;
        }
    }
}
