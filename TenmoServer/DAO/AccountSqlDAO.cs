using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TenmoServer.DAO
{
    public class AccountSqlDAO : IAccountDAO
    {
        private readonly string connectionString;
        //const decimal startingBalance = 1000;

        public AccountSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public decimal GetBalance(int accountId)
        {
            decimal balance = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT balance FROM accounts WHERE account_id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", accountId);

                    balance = Convert.ToDecimal(cmd.ExecuteScalar());
                }
                return balance;
            }
            catch (SqlException)
            {
                throw;
            }
        }

    }
}
