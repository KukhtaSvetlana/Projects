using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Лаб2
{
    class WriteFile
    {
        public bool Check { get; private set; }
        public void WriteInFile(List<string> list, string path)
        {
            
                if (File.Exists(path))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
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
            Check = true;
            }
        }
    }

