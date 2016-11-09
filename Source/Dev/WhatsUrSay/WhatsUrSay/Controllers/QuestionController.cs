using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class QuestionController : ApiController
    {
        QuestionRepository repo = new QuestionRepository();

        public Question PostQuestion(Question question)
        {
            return repo.Add(question);
        } 
    }
}
