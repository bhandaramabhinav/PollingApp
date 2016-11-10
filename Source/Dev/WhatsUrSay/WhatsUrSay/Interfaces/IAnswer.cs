using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsUrSay.Models;

namespace WhatsUrSay
{
    interface IAnswer
    {
        IEnumerable<Answer> GetAll();
        Answer Get(int id);
        Answer Add(Answer Act);
        bool Update(Answer Act);
        bool Delete(int id);
    }
}
