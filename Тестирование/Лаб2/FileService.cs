using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Лаб2
{
   public class FileService: IFileService
    {
        FileInfo file1;
        FakeFileService fakeFile = new FakeFileService();
        List<string> buffer2 = new List<string>(); 
        ReadFile _readfile = new ReadFile();
        WriteFile writeFile = new WriteFile();
        DeleteFile deleteFile = new DeleteFile();
        private static string PathInFaleForCreateAndWrite = @"D:\Laboratory_works\Тестирование\File_test\bacup.tmp";
        FileInfo file = new FileInfo(PathInFaleForCreateAndWrite);
        int delete = 0;
        string buckup;
        public int MergeTemporaryFiles(string dir)
        {
            try
            {
                var path = Directory.GetFiles(dir, "*.tmp "); 
                int quantity_fileInDirectory = path.Count();
                var bufer = _readfile.Read_File(path);
                Set_ReadFile(bufer);
                deleteFile.DeleteInFile(path);
                int delete = deleteFile.Get_Number();
                Set_int(delete);
                if (!File.Exists(PathInFaleForCreateAndWrite))
                {
                    StreamWriter sr = file.CreateText();
                    sr.Close();
                    writeFile.WriteInFile(bufer, PathInFaleForCreateAndWrite);
                }
                else
                {
                  writeFile.WriteInFile(bufer, PathInFaleForCreateAndWrite);
                }
                MessageBox.Show("Файл записан");
                return quantity_fileInDirectory; 
             }
            catch(Exception ex)
            {
                throw new Exception("Not this file");
            }
        }
        public int MergeTemporaryFilesOne(string dir)
        {
            try
            {
                var path = Directory.GetFiles(dir, "*.tmp ");
                int quantity_fileInDirectory = path.Count();
                var bufer = fakeFile.registrationFile();
                Set_ReadFile(bufer);
                int delete =  fakeFile.DeleteFile();
                Set_int(delete);
                 Set_stroka(fakeFile.backupFile());
                //if (!File.Exists(PathInFaleForCreateAndWrite))
                //{
                //    StreamWriter sr = file.CreateText();
                //    sr.Close();
                //    writeFile.WriteInFile(bufer, PathInFaleForCreateAndWrite);
                //}
                //else
                //{
                //    writeFile.WriteInFile(bufer, PathInFaleForCreateAndWrite);
                //}
                MessageBox.Show("Файл записан");
                return quantity_fileInDirectory;
            }
            catch (Exception ex)
            {
                throw new Exception("Not this file");
            }
        }
        public void Set_ReadFile(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                buffer2.Add(list[i]);
            }
        }
        public List<string> Get()
        {
            return buffer2;
        }
        public void Set_int(int del)
        {
            this.delete = del;
        }
        public void Set_stroka(string del)
        {
            this.buckup = del;
        }
        public string Get_stroka()
        {
            return this.buckup;
        }
        public int Get_int()
        {
            return delete;
        }
    }
}
