using StringFormat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInk
{
    class LinksRepository
    {
        List<string> countries = new List<string>();
        public void Add(string link)
        {
            StringSafe str = new StringSafe();
            string s = str.WebString(link);
            countries.Add(s);
        }
    }
}
