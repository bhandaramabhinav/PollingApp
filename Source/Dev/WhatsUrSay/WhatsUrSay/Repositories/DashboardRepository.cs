using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Repositories;
using WhatsUrSay.Models;
using WhatsUrSay.Interfaces;

namespace WhatsUrSay.Repositories
{
    public class DashboardRepository : IDashBoardRepository
    {
        public dynamic Get(DashboardInput userInfo)
        {
            DSEEntities objEntities = new DSEEntities();
            List<Activity> privateActivities = new List<Activity>();
            List<Group> userCreatedGroups = new List<Group>();
            List<User_Request> userRequests = new List<User_Request>();
            List<Activity_Group> groupActivities = new List<Activity_Group>();
            var publicActivites = objEntities.Activities.Where(act => act.type == 1).ToList();
            var createdActivities = objEntities.Activities.Where(act => act.createdby == userInfo.userId).ToList() ;
            var userGroups = objEntities.User_Group.Where(group => group.user_id == userInfo.userId).ToList();
            if (userGroups != null)
            {
                foreach (var grp in userGroups)
                {
                    groupActivities = objEntities.Activity_Group.Where(actgrp => actgrp.group_id == grp.group_id).ToList();                    
                }
            }
            if (groupActivities != null)
            {
                foreach (var grpact in groupActivities)
                {
                    var activity = objEntities.Activities.Where(act => act.id == grpact.id).FirstOrDefault();
                    privateActivities.Add(activity);
                }
            }
            if (userInfo.role != 2)
            {
                userCreatedGroups = objEntities.Groups.Where(grp => grp.createdby == userInfo.userId).ToList();
            }
            if (userInfo.role == 3)
            {
                userRequests = objEntities.User_Request.ToList();
            }
            DashboardOutput objDBOutput = new DashboardOutput();
            objDBOutput.groups = userCreatedGroups;
            objDBOutput.privateActivities = privateActivities;
            objDBOutput.publicActivities = publicActivites;
            objDBOutput.requests = userRequests;
            objDBOutput.createdActitvities = createdActivities;
            return objDBOutput;
        }
    }
}