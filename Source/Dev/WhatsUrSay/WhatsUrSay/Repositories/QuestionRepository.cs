using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class QuestionRepository
    {
        private DSEEntities db = new DSEEntities();

        public Question Add(Question question)
        {
            if (question == null)
                throw new ArgumentNullException("question");

            db.Questions.Add(question);
            db.SaveChanges();
            return question;
        }
    }
}