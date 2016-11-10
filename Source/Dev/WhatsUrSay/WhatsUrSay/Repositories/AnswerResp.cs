using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay
{
    public class AnswerResp: IAnswer
    {
        DSEEntities Db2 = new DSEEntities();

        public IEnumerable<Answer> GetAll()
        {
            // TO DO : Code to get the list of all the records in database
            return Db2.Answers;
        }

        public Answer Get(int id)
        {
            // TO DO : Code to find a record in database
            return Db2.Answers.Find(id);
        }

        public Answer Add(Answer Ans)
        {
            if (Ans == null)
            {
                throw new ArgumentNullException("Answer");
            }

            // TO DO : Code to save record into database
            Db2.Answers.Add(Ans);
            Db2.SaveChanges();
            return Ans;
        }

        public bool Update(Answer Ans)
        {
            if (Ans == null)
            {
                throw new ArgumentNullException("Answer");
            }

            // TO DO : Code to update record into database
            var Answer1 = Db2.Answers.Single(a => a.id == Ans.id);
            Answer1.id = Ans.id;
            Answer1.description = Ans.description;
            Answer1.count = Ans.count;
            Answer1.activity_id = Ans.activity_id;
            Answer1.question_id = Ans.question_id;
            Db2.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            // TO DO : Code to remove the records from database
            Activity products = Db2.Activities.Find(id);
            Db2.Activities.Remove(products);
            Db2.SaveChanges();
            return true;
        }
    }
}