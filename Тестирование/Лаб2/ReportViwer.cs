using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаб2
{
    public class ReportViwer
    {
        private int _BlockCount ;
        private readonly IFileService _file;

        //public ReportViwer(Boolean isReal)
        //{
        //    if (isReal)
        //        _file = new FileService();
        //    else
        //        _file = new FakeFileService();
              
           
        //}

        public ReportViwer(IFileService file)
        {
            _file = file;

        }
        public int PrepareDate(string path)
        {
                if (!System.IO.Directory.Exists(path)) //проверка на директорию
                {
                    throw new NullReferenceException("This Directory not created");
                }
                int result = _file.MergeTemporaryFiles(path);
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                SetBlockCount(result);
                    return result;
                } 
        }
        public void SetBlockCount(int result)
        {
            this._BlockCount = result;
        }
        public int GetBlockCount()
        {
            return this._BlockCount;
        }
    }
}
