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
    public class AccountsController : ControllerBase
    {
        private IAccountDAO AccountDAO;

        public AccountsController(IAccountDAO accountDAO)
        {
            this.AccountDAO = accountDAO;
        }

        [HttpGet("{accountId}")]
        public ActionResult<Account> GetAccount (int accountId)
        {
            Account account= AccountDAO.GetAccount(accountId);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        [HttpGet]
        public ActionResult<List<Account>> GetAccounts()
        {
            List<Account> accounts = AccountDAO.GetAccounts();
            if (accounts == null)
            {
                return NotFound();
            }
            return accounts;
        }
    }
}
