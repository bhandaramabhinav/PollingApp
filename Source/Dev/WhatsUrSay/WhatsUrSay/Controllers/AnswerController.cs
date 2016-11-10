using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Controllers
{
    public class AnswerController : ApiController
    {

        static readonly IAnswer Answer1 = new AnswerResp();

        public IEnumerable<Answer> GetAnswers()
        {
            return Answer1.GetAll();
        }

        public Answer PostSurvey(Answer Act)
        {
            return Answer1.Add(Act);
        }

        public IEnumerable<Answer> PutSurvey(int id, Answer Ans)
        {
            Ans.id = id;
            if (Answer1.Update(Ans))
            {
                return Answer1.GetAll();
            }
            else
            {
                return null;
            }
        }

        public bool DeleteAnswer(int id)
        {
            if (Answer1.Delete(id))
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
