using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenmoServer.DAO;

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

        //[HttpGet("{accountId}")]
        //public decimal GetBalance(int accountId)
        //{
        //    return AccountDAO.GetBalance(accountId);
        //}

    }
}
