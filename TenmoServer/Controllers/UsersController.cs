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
        public List<User> GetUsers()
        {
            return UserDAO.GetUsers();
        }

        //TODO : add authorization for getting user
        //[Authorize(Roles = "ReturnUser")]
        [HttpGet("{username}")]
        public ActionResult<List<Account>> GetAccountByUsername(string username)
        {

            List<Account> accounts = AccountDAO.GetAccounts(username);
            if(accounts == null)
            {
               return NotFound();
            }
            return accounts;
        }

        //[HttpGet("{username}/{accountId}")]
        //public ActionResult<Account> GetUserAccount(string username, int accountId)
        //{
        //    User user = UserDAO.GetUser(username);
        //    Account userAccount = AccountDAO.GetAccount(username);
        //}
    }
}
