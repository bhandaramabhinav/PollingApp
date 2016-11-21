using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class ActivityGroupDetails
    {
        /*public Group group { get; set; }
        public Activity activity { get; set; }*/
        public String heading { get; set; }
        public String description { get; set; }
        public int type { get; set; }
        public int category { get; set; }
        public int createdby { get; set; }

        public HashSet<Question> Questions { get; set; } 
        public HashSet<Answer> Answers { get; set; }
        public HashSet<Group> Groups { get; set; }
    }
}