using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class GroupmvcController : Controller
    {
        // GET: GroupsMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: GroupsMVC/Details/5
        public  static readonly string  baseUri="http://localhost:61972/";


        public  async Task<ActionResult> Details(int id)
        {
            using (HttpClient webClient = new HttpClient())
            {
                webClient.BaseAddress = new Uri(baseUri);
                webClient.DefaultRequestHeaders.Accept.Clear();
                webClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await webClient.GetAsync("api/Groups/GetGroup/?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var groupDetails = response.Content.ReadAsAsync<GroupDetails>();
                }

                return View();
            }
            
        }


        /// <summary>
        /// Method to Create New Group
        /// </summary>
        /// <param name="newGroup"></param>
        /// <returns></returns>
        // POST: GroupsMVC/Create
       [HttpPost]
        public ActionResult Create(Group newGroup)
        {
            try
            {
                using (HttpClient webClient = new HttpClient())
                {
                    webClient.BaseAddress = new Uri(baseUri);
                    webClient.PostAsJsonAsync<Group>("api/Groups/Postgroup", newGroup);
                    // TODO: Add insert logic here

                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }


        /// <summary>
        /// Method to Update Group Details
        /// </summary>
        /// <param name="editGroup"></param>
        /// <returns></returns>
        // POST: GroupsMVC/Edit/5
        [HttpPost]
        public ActionResult Edit (Group editGroup)
        {
            try
            {

                using (HttpClient webClient = new HttpClient())
                {
                    webClient.BaseAddress = new Uri(baseUri);
                    webClient.PutAsJsonAsync("api/Groups/PutGroup", editGroup);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Method To Delete Group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: GroupsMVC/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {

                using (HttpClient webClient = new HttpClient())
                {
                    webClient.BaseAddress = new Uri(baseUri);
                    webClient.DeleteAsync("api/Groups/DeleteGroup?id=" + id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
           
        }

    }
}
