using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.DTO;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class ActivityDTORespository
    {
        private DSEEntities db = new DSEEntities();

        public IQueryable<ActivityDTO> GetPolls()
        {
            var polls = from b in db.Activities
                        select new ActivityDTO()
                        {
                            heading = b.heading,
                            description = b.description,
                            questionId = b.Questions.FirstOrDefault().id,
                            question = b.Questions.FirstOrDefault().description,
                            options = (HashSet<string>)b.Answers.Select(x => x.description)
                        };
            return polls;
        }

        public IQueryable<ActivityDTO> GetPoll(int id)
        {
            var poll = from b in db.Activities
                       where (b.id == id)
                       select new ActivityDTO()
                       {
                           heading = b.heading,
                           description = b.description,
                           questionId = b.Questions.FirstOrDefault().id,
                           question = b.Questions.FirstOrDefault().description,
                           options = (HashSet<string>)b.Answers.Select(x => x.description)
                       };
            return poll;
        }


    }
}