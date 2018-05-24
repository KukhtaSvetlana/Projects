using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringFormat
{
    public class StringSafe
    {
        public string SaveString(string s)
        {
            string str;
            int num;
            bool isNum = int.TryParse(s, out num);
            ;
            if (isNum)
            {
                return "Это число";
            }
            if (s == null)
            {
              throw new NullReferenceException("This Null");
            }
            if (s == "")
            {
                return "";
            }
            string start_string = s.Substring(0, 1);
            int param = s.Length - 1;
            string finish_string = s.Substring(param, 1);
            if (start_string!= finish_string)
            {
                return s;
            }
            
            str =s.ToLower().Replace("select", "SELECT").Replace("update", "UPDATE").Replace("delete", "DELETE").Replace("insert", "INSERT");
            str = str.Replace("'", "'''"); 
            return str;
        }
        public string WebString(string _Link)
        {
            string linkFinish = "";
            if (_Link == null)
            {
                throw new NullReferenceException("This Null");
            }
            if (_Link == "")
            {
                return "";
            }
            if (!_Link.StartsWith("httt://"))
            {
                linkFinish = "httt://" + _Link;
            }
            if (_Link.EndsWith(".git"))
            {
                linkFinish = "git://" + _Link;
            }
            return linkFinish;
        }
    }
}
