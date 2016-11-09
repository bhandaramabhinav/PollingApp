using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUrSay.Models
{
    public class GroupDetails
    {
        public Group group { get; set; }
        public List<UserDetails> UserList {get; set;}
    }
}