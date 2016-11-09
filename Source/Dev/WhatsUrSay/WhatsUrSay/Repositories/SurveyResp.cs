using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay
{
    public class SurveyResp : ISurvey
    {
            DSEEntities Db1 = new DSEEntities();

            public IEnumerable<Activity> GetAll()
            {
                // TO DO : Code to get the list of all the records in database
                return Db1.Activities;
            }

            public Activity Get(int id)
            {
                // TO DO : Code to find a record in database
                return Db1.Activities.Find(id);
            }

            public Activity Add(Activity Act)
            {
                if (Act == null)
                {
                    throw new ArgumentNullException("Activity");
                }

                // TO DO : Code to save record into database
                Db1.Activities.Add(Act);
                Db1.SaveChanges();
                return Act;
            }

            public bool Update(Activity Act)
            {
                if (Act == null)
                {
                    throw new ArgumentNullException("Activity");
                }

                // TO DO : Code to update record into database
                var Survey1 = Db1.Activities.Single(a => a.id == Act.id);
                Survey1.heading = Act.heading;
                Survey1.description= Act.description;
                Survey1.type= Act.type;
                Survey1.category = Act.category;
                Survey1.group_ids = Act.group_ids;
                Db1.SaveChanges();
            
                return true;
            }

            public bool Delete(int id)
            {
                // TO DO : Code to remove the records from database
                Activity products = Db1.Activities.Find(id);
                Db1.Activities.Remove(products);
                Db1.SaveChanges();
                return true;
            }
        

    }
}