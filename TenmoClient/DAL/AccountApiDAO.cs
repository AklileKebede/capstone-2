using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text;
using TenmoClient.Data;

namespace TenmoClient.DAL
{
    public class AccountApiDAO : IAccountDAO
    {
        private readonly RestClient client;

        public AccountApiDAO(string api_url)
        {
            client = new RestClient(api_url);
            client.Authenticator = new JwtAuthenticator(UserService.GetToken());
        }

        //public decimal GetBalance(int accountId)
        //{
        //    RestRequest request = new RestRequest($"accounts/{accountId}");
        //  url/users/username/1
        //  url/accounts/
        //}

        public Account GetAccount(string username, int accountId)
        {
            RestRequest request = new RestRequest($"users/{username}/accounts/{accountId}");
            //accounts/accountId

            IRestResponse<Account> response = client.Get<Account>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                //ProcessErrorResponse(response);
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }


        }

        public Account GetAccount( int accountId)
        {
            RestRequest request = new RestRequest($"accounts/{accountId}");
            //accounts/accountId

            IRestResponse<Account> response = client.Get<Account>(request);
            if (response.ResponseStatus != ResponseStatus.Completed || !response.IsSuccessful)
            {
                //ProcessErrorResponse(response);
                throw new Exception("Error occurred - unable to reach server: " + (int)response.StatusCode);
            }
            else
            {
                return response.Data;
            }
        }
    }
}
