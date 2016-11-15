/* File Name :GroupsRepository.cs
 * Created By: Raj
 * This File resides in Business Layer 
 * 
 * Change History
 ************************
 ** PR   Date        Author         Description 
 ** --   --------   -------   ------------------------------------
 ** 1    11/6/2016     Raj      Created GroupsRepository class and incuded methods  to modify group data
 *  2    11/15/2016     Raj     implemeted IGroupsRepository methods
 * This file  performs CRUD operations on Group Table
 * 
*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using WhatsUrSay.Interfaces;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class GroupsRepository:IGroupsRepository
    {
        private DSEEntities db = new DSEEntities();

        /// <summary>
        /// This method returns all groups
        /// </summary>
        /// <returns></returns>
        public IQueryable<Group> GetGroups()
        {
            return db.Groups;
        }

        /// <summary>
        /// This method returns specific group details
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public GroupDetails GetGroup(int groupId)
        {
            Group group = db.Groups.Find(groupId);
            if (group == null)
            {
                throw new ArgumentNullException("Group not found");
            }
            GroupDetails groupDetails;
            try
            {
            groupDetails = new GroupDetails();
            groupDetails.group = group;
            groupDetails.UserList = new List<UserDetails>();
            string[] users = group.user_ids.Split(',');

            foreach (var userId in users)
            {
                User user = db.Users.Find(Int32.Parse(userId));

                groupDetails.UserList.Add(new UserDetails() { Id = user.id, Name = user.name });
            }
            }
            catch (Exception)
            {

                throw;
            }
            return groupDetails;
        }

        /// <summary>
        /// This method updates group details
        /// </summary>
        /// <param name="group"></param>
        /// <returns>true or false   </returns>
        public bool UpdatGroup(Group group)
        {
            db.Entry(group).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {

                return false;

            }

            return true;
        }

        /// <summary>
        /// This method returns created group details
        /// </summary>
        /// <param name="group"></param>
        /// <returns> created group  object</returns>
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

        /// <summary>
        /// Deletes group
        /// </summary>
        /// <param name="id"></param>
        /// <returns> deteleted group object</returns>
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

        /// <summary>
        /// Finds if group exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns> true or false</returns>
        private bool GroupExists(int id)
        {
            return db.Groups.Count(e => e.id == id) > 0;
        }


        
    }
}