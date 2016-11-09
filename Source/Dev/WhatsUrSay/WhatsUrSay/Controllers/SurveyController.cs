using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WhatsUrSay.Models;

namespace WhatsUrSay.Controllers
{
    public class SurveyController : ApiController
    {
            static readonly ISurvey Survey1 = new SurveyResp();

            public IEnumerable<Activity> GetAllSurveys()
            {
                return Survey1.GetAll();
            }

            public Activity PostSurvey(Activity Act)
            {
                return Survey1.Add(Act);
            }

            public IEnumerable<Activity> PutSurvey(int id, Activity Act)
            {
                Act.id = id;
                if (Survey1.Update(Act))
                {
                    return Survey1.GetAll();
                }
                else
                {
                    return null;
                }
            }

            public bool DeleteSurvey(int id)
            {
                if (Survey1.Delete(id))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        

    }
}
