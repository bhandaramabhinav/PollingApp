using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class UserRepository:IUserRepository
    {
        DSEEntities objEntities = new DSEEntities();
        public User Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            objEntities.Users.Add(user);
            objEntities.SaveChanges();
            return user;
        }
        public User Find(string uName)
        {
            if (String.IsNullOrEmpty(uName))
            {
                throw new ArgumentNullException("user name");
            }            
            return objEntities.Users.Where(user => user.emailId == uName).FirstOrDefault();
        }
    }
}