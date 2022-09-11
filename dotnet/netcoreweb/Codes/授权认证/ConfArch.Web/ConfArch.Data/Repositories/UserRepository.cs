using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConfArch.Data.Models;

namespace ConfArch.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>
        {
            new User { Id = 3522, Name = "roland", Password = "K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=",
                FavoriteColor = "blue", Role = "Admin", GoogleId = "104938080003463226601" }
        };
        public User GetByUsernameAndPassword(string username, string password)
        {
            var user = users.SingleOrDefault(u => u.Name == username &&
                                                  u.Password == password);
            return user;
        }

        public User GetByGoogleId(string googleId)
        {
            var user = users.SingleOrDefault(u => u.GoogleId == googleId);
            return user;
        }
    }
}
