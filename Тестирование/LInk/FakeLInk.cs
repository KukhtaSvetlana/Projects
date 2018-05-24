using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInk
{
    class FakeLInk: ILink
    {
        public bool Check_FakeFileService { get; private set; }
        public List<string> WebString(List<string> _Link)
        {
            Check_FakeFileService = true;
            List<string> link = new List<string> { "https://google.com", "https://metanit.com", "https://github.com" };
            return link ;
        }
    }
}
