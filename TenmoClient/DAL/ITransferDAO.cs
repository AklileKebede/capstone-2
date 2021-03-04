using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    public interface ITransferDAO
    {
        List<API_User> GetUsers();
    }
}