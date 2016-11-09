using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class PollController : ApiController
    {
        PollRepository repo = new PollRepository();
      
        public IEnumerable<Activity> GetAllPolls()
        {
             return repo.GetAll();
        }

        public Activity GetPoll(int id)
        {
            return repo.Get(id);
        }
        
        public Activity PostPoll(Activity activity)
        {
            return repo.Add(activity);
        }
        
        public IEnumerable<Activity> PutPoll(int id,Activity activity)
        {
            activity.id = id;
            if (repo.Update(activity))
                return repo.GetAll();
            else
                return null;
        }

        public bool DeletePoll(int id)
        {
            if (repo.Delete(id))
                return true;
            else
                return false;
        }
    }
}
