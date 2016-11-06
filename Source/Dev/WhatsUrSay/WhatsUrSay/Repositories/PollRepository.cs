using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class PollRepository
    {
        private DSEEntities db = new DSEEntities();

        public IEnumerable<Activity> GetAll()
        {
            return db.Activities.ToList();
        }

        public Activity Get(int id)
        {
            return db.Activities.Find(id);
        }

        public Activity Add(Activity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");

            db.Activities.Add(activity);
            db.SaveChanges();
            return activity;
        }

        public bool Update(Activity updated)
        {
            if (updated == null)
                throw new ArgumentNullException("updated");

            var activity = db.Activities.Single(a => a.id == updated.id);
            activity.heading = updated.heading;
            activity.description = updated.description;
            activity.category = updated.category;
            activity.type = updated.type;
            activity.group_ids = updated.group_ids;

            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return true;
        }
    }
}