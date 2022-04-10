using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using ServicesUser;
using UserAPI.Service;

namespace AuthenticationAPI.Repository
{
    public class LoginRepository
    {
    
        public async Task<ActionResult<User>> Get(string login, string password)
        {
            var user = await ServiceSeachUser.SeachUserAuth(login);        

            if (user != null)
            {
                var users = new List<User>
            {
               new () { Id= "1", Login = user.Login, Password = user.Password, Role = user.Role },
            };

                return users
                .FirstOrDefault(x => x.Login == login && x.Password == password);

            }
            else
            {
                return null;
            }
          
                
            
        }
    }
}
