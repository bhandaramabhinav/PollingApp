using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUserRepository objUserRepository = new UserRepository();
        // GET api/<controller>/5
        public User Get(string uName)
        {
            return objUserRepository.Find(uName);
        }

        // POST api/<controller>
        public bool Post([FromBody]User user)
        {
            User objUser = objUserRepository.Add(user);
            if (User != null)
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