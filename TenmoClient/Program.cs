﻿using System;
using System.Collections.Generic;
using TenmoClient.Data;
using TenmoClient.Views;

namespace TenmoClient
{
    class Program
    {
        private readonly static string API_BASE_URL = "https://localhost:44315/";
        static void Main(string[] args)
        {

            AuthService authService = new AuthService(API_BASE_URL);
            new LoginRegisterMenu(authService).Show();

            Console.WriteLine("\r\nThank you for using TEnmo!!!\r\n");
        }
    }
}
