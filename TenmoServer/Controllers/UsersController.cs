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
    [Authorize]
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

        [HttpGet("{accountId}")]
        public List<User> GetUserAccounts(int accountId)
        {
            //return AccountDAO.
        }

    }
}
