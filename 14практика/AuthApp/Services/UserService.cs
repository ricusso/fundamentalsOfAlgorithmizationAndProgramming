using System.Collections.Generic;
using System.Linq;

namespace AuthApp
{
    public static class UserService
    {
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "JasminFazilova", Login = "Jasmin",
                      Password = "Jasmin123" },
            new User { Id = 2, Name = "KiraChernysheva", Login = "Kira",
                      Password = "Kira123"},
          
        };

        public static User Authenticate(string login, string password)
        {
            return users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}