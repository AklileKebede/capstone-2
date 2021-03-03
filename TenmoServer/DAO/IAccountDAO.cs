using System.Collections.Generic;
using TenmoServer.Models;

namespace TenmoServer.DAO
{
    public interface IAccountDAO
    {
        List<Account> GetAccounts(string username);
        List<Account> GetAccounts();
        Account GetAccount(string username, int accountId);
        Account GetAccount(int accountId);
        decimal GetBalance(int accountId);
    }
}