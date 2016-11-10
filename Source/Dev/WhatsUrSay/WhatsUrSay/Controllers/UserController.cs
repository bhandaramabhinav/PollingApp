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
        static readonly IUserRepository objRepository = new UserRepository();
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            //return new string[] { "value1", "value2" };
            return null;
        }

        // GET api/<controller>/5
        public User Get(string uName)
        {
            return objRepository.Find(uName);
        }

        // POST api/<controller>
        public bool Post([FromBody]User user)
        {
            User objUser = objRepository.Add(user);
            if (User != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}