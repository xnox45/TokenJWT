using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenJwtEstudo.Model;

namespace TokenJwtEstudo.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            List<User> users = new List<User>();
            users.Add(new User {Id = 1, Password = "teste", UserName = "fred", Role = "dev"});
            users.Add(new User {Id = 2, Password = "teste", UserName = "juh", Role = "vendedor"});

            return users.FirstOrDefault(x => string.Equals(x.UserName, username, StringComparison.CurrentCultureIgnoreCase) && 
            x.Password == password);
        }
    }
}
