using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    public class AccountApiDAO
    {
        private RestClient client;

        public AccountApiDAO(string api_url)
        {
            client = new RestClient(api_url);
        }

        //public decimal GetBalance(int accountId)
        //{
        //    RestRequest request = new RestRequest($"accounts/{accountId}");
        //  url/users/username/1
        //  url/accounts/
        //}

        public Account GetAccount(int accountId)
        {
            RestRequest request = new RestRequest($"accounts/{accountId}");
            //accounts/accountId

            // TODO: UPDATE ME THIS WAS COPY AND PASTED IN!!!!
            IRestResponse<Account> response = client.Get<Account>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                //ProcessErrorResponse(response);
            }
            else
            {
                return response.Data;
            }

            return null;
        }
    }
}
