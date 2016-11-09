using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Repositories
{
    public class LoginRepository:ILoginRepository
    {
        public bool Login(string uName, string uPassword)
        {
            UserRepository objUserRepository = new UserRepository();
            User user = objUserRepository.Find(uName);
            if (user == null)
            {
                return false;
            }
            else
            {
                if(String.Equals(user.pwd, uPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }            
        }
    }
}