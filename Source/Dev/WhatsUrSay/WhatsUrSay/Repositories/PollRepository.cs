/*
Component :                             A class that does 'insert' and 'read' operations on the 'Activity' table of our project's database (DSE)
Author:                                 Sreedevi Koppula
Use of the component in system design:  Used for performing 'insert' and 'read' operations on the 'Activity' table 
Written and revised:                    11/5/2016
Reason for component existence:         To perform 'insert' and 'read' operations on the 'Activity' table 
Component usage of data structures, algorithms and control(if any): 
    Uses Entity framework class 'Activity.cs' to do 'insert' and 'read' operations on 'Activity' table
    The component contains the below methods:
        'GetAll()', 'Get(int id)', 'Add(Activity activity)'
    These methods are invoked by 'PollController', a Web Api controller that serves the clients' requests
*/
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using WhatsUrSay.Models;

namespace WhatsUrSay.Repositories
{
    public class PollRepository
    {
        private DSEEntities db = new DSEEntities();

        //Purpose: Gets all the records of type 'poll' from the 'Activity' table
        //Input: None
        //Output: A list of poll records from the 'Activity' table
        //        If any exception occurs, the exception message is printed and the exception is thrown
        public IEnumerable<Activity> GetAll()
        {
            try
            {
                return db.Activities.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                throw e;
            }
            
        }

        //Purpose: Gets a record from the 'Activity' table whose row id is 'id'
        //Input: 'id' of the required record
        //Output: a record from 'Activity' table whose key is 'id'
        //        If any exception occurs, the exception message is printed and the exception is thrown
        public Activity Get(int id)
        {
            try
            {
                return db.Activities.Find(id);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                throw e;
            }
            
        }

        //Purpose: Adds an object 'activity' in the 'Activity' table
        //Input: 'activity' object of type 'Activity.cs'
        //Output: Returns the object 'activity' upon its successful addition in the table
        //        If any exception occurs, the exception message is printed and the exception is thrown
        public Activity Add(ActivityGroupDetails act)
        {
            if (act == null)
                throw new ArgumentNullException("activity");

            try
            {
                LinkedList<Activity_Group> grps = new LinkedList<Activity_Group>();
                //Activity_Group ag = new Activity_Group();
                foreach (Group g in act.Groups)
                {
                    Activity_Group ag = new Activity_Group();
                    ag.group_id = (db.Groups.Where(group => group.name == g.name).FirstOrDefault()).id;
                    grps.AddLast(ag);
                    //grps.Add(ag);
                }

                Activity activity = new Activity();
                activity.heading = act.heading;
                activity.description = act.description;
                activity.type = act.type;
                activity.category = act.category;
                activity.createdby = act.createdby;
                activity.Questions = act.Questions;
                activity.Answers = act.Answers;
                activity.Activity_Group = grps;
                db.Activities.Add(activity);
                db.SaveChanges();

                
                return activity;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
                throw e;
            }
        }
    }
}