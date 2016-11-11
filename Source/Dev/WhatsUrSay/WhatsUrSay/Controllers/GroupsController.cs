using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WhatsUrSay.Models;
using WhatsUrSay.Repositories;

namespace WhatsUrSay.Controllers
{
    public class GroupsController : ApiController
    {
        GroupsRepository groupRepository = new GroupsRepository();

        // GET: api/Groups
        public IQueryable<Group> GetGroups()
        {
            return groupRepository.GetGroups();
        }

        // GET: api/Groups/5
        [ResponseType(typeof(GroupDetails))]
        public IHttpActionResult GetGroup([FromUri]int id)
        {

            GroupDetails groupDetails = groupRepository.GetGroup(id);
            return Ok(groupDetails);
        }

        // PUT: api/Groups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                groupRepository.UpdatGroup(group);
            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
               
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Groups
        [ResponseType(typeof(Group))]
        public IHttpActionResult PostGroup(Group group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                groupRepository.CreateGroup(group);
            }
            catch (DbUpdateException)
            {
                
                    throw;
            }

            return CreatedAtRoute("DefaultApi", new { id = group.id }, group);
        }

        // DELETE: api/Groups/5
        [ResponseType(typeof(Group))]
        public IHttpActionResult DeleteGroup([FromUri]int id)
        {
            Group group = groupRepository.DeleteGroup(id);

            return Ok(group);
        }

      

    }
}