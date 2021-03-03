using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        List<Account> GetAccounts(string username);
        decimal GetBalance(int accountId);
    }
}