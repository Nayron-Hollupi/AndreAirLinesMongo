using System.Collections.Generic;
using System.Linq;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Repository
{
    public class LoginRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>
            {
               new () { Id= "1", UserName = "Nayron", Password = "123456", Role = "manager" },
               new () { Id= "2", UserName = "Daiane", Password = "654321", Role = "employee" }
            };

            return users
            .FirstOrDefault(x => x.UserName == userName && x.Password == password);

        
        }
    }
}
