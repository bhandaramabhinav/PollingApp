using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class GroupsRepository
    {
        private DSEEntities db = new DSEEntities();

        public IQueryable<Group> GetGroups()
        {
            return db.Groups;
        }

        public GroupDetails GetGroup(int groupId)
        {
            Group group = db.Groups.Find(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("Group not found");
            }
            GroupDetails groupDetails = new GroupDetails();
            groupDetails.group = group;
            groupDetails.UserList = new List<UserDetails>();
            string[] users = group.user_ids.Split(',');

            foreach (var userId in users)
            {
                User user = db.Users.Find(Int32.Parse(userId));

                groupDetails.UserList.Add(new UserDetails() { Id = user.id, Name = user.name });
            }

            return groupDetails;
        }

        public bool UpdatGroup(Group group)
        {
            db.Entry(group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return true;
        }

        public Group CreateGroup(Group group)
        {
            

            db.Groups.Add(group);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GroupExists(group.id))
                {
                    throw new Exception("Conflit");
                }
                else
                {
                    throw;
                }
            }

            return group;
        }


        public Group DeleteGroup(int id)
        {
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                throw new ArgumentNullException("Group not found to delete");
            }

            db.Groups.Remove(group);
            db.SaveChanges();

            return group;

        }

        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.id == id) > 0;
        }


        
    }
}