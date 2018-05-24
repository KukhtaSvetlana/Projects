using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_lab8
{
    class WriteFile
    {
        public void Write(List<string> list, string path)
        { 
            
            if (File.Exists(path))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(path, false, Encoding.Default))
                    {
                        for (int i = 0; i < list.Count; i++)
                        {
                            sw.WriteLine(list[i]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                throw new Exception("Not this file");
            }
        }
    }
}
