using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;
using WhatsUrSay.DTO;

namespace WhatsUrSay.Controllers
{
    public class ActivityDTOController : ApiController
    {
        PollRepository repo = new PollRepository();

        //Purpose: Invokes 'GetAll()' method of PollRepository.cs that returns all the records of type 'poll' from the 'Activity' table
        //Input: None
        //Output: A list of poll records from the 'Activity' table
        public IQueryable<ActivityDTO> GetAllPolls()
        {
            return repo.GetPolls();
        }

        //Purpose: Invokes 'Get(int id)' method of PollRepository.cs that returns a record from the 'Activity' table whose key is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Activity' table whose key is 'id'
        public IQueryable<ActivityDTO> GetPoll(int id)
        {
            return repo.GetPoll(id);
        }
    }
}
