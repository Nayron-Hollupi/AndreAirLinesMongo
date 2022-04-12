﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Model;
using Newtonsoft.Json;

namespace ServicesUser
{
    public class ServiceSeachUser
    {
      
            static readonly HttpClient user = new HttpClient();

            public static async Task<User> SeachUserAuth(string Login)
            {
                try
                {
        
                HttpResponseMessage response = await user.GetAsync("https://localhost:44307/api/User/" + Login);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var userJson = JsonConvert.DeserializeObject<User>(responseBody);
                    return userJson;
                }
                catch (Exception)
                {

                    return null;
                    //throw;
                }
            }

     
    }
}
