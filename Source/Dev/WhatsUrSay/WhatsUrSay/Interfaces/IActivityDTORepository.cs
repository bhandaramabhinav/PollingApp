using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay.Interfaces
{
    interface IActivityDTORepository
    {
        IEnumerable<Activity> GetAll();
        IEnumerable<Activity> GetPoll(int id);
    }
}
