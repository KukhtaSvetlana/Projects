using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб2
{
    class ReadFile
    {
        private List<string> Read_text_is_fale;
        public ReadFile()
        {
            Read_text_is_fale  = new List<string>();
        }
         public List<string> Read_File(string[] path)
        {
            for (int i = 0; i < path.Length; i++)
            {
                if (File.Exists(path[i]))
                {
                    using (StreamReader file_read = new StreamReader(path[i], Encoding.Default))
                    {
                        Read_text_is_fale.Add(file_read.ReadToEnd());
                        file_read.Close();
                    }
                }
                else
                {
                    throw new Exception("Not this file");
                }
            }
            return this.Read_text_is_fale;
        }
    }
}
