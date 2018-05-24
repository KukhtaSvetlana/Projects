using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб2
{
   public class FakeFileService:IFileService
    {
        public bool Check_FakeFileService { get; private set; }
        public int MergeTemporaryFiles(string dir)
        {
            Check_FakeFileService = true;
            return 5;
        }
        public string backupFile()
        {
            Check_FakeFileService = true;
            return "bacup.tmp";
        }
        public List<string> registrationFile()
        {
            Check_FakeFileService = true;
            List<string> list = new List<string> { "Hello\r\n", "world", "this", "crazy\r\n", "File" };
            return list;
        }
        public int DeleteFile()
        {
            Check_FakeFileService = true;
            return 5;
        }
    }
}
