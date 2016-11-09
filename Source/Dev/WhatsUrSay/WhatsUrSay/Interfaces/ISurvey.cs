using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay
{
    interface ISurvey
    {
        
            IEnumerable<Activity> GetAll();
            Activity Get(int id);
            Activity Add(Activity Act);
            bool Update(Activity Act);
            bool Delete(int id);
        }
    }
