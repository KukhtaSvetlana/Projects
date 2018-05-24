using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Лаб2
{
   public class DeleteFile
    {
        public bool Check { get; private set; }
        private int number_deleteFile;
        public void DeleteInFile(string[] list)
        { 
            try
            {
                for (int i = 0; i < list.Length; i++)
                {
                    File.Delete(list[i]);
                    ++this.number_deleteFile;
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Check = true;
        }
        public int Get_Number()
        {
            return this.number_deleteFile;
        }
    }
}
