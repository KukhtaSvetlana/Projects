using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаб2;
using Moq;
using System.IO;

namespace FileServiseTest
{
    
    [TestFixture]
    public class TestClass
    {
        FakeFileService fakeFileService = new FakeFileService();
        private readonly Mock<IFileService> _mock_Check = new Mock<IFileService>();
        [Test]
        public void PrepareDate_Path_CheckNumberFile() //проверка вызова метода 
        {
            ReportViwer viwer = new ReportViwer(_mock_Check.Object);
            viwer.PrepareDate(@"D:\Laboratory_works");
            _mock_Check.Verify(m => m.MergeTemporaryFiles(@"D:\Laboratory_works") );
        }
        //readonly ReportViwer viwer = new ReportViwer(new FakeFileService(), @"D:\Laboratory_works");
        
        [Test]
        public void PrepareDate_Path_NumberFile() //Stab
        {
           ReportViwer viwer = new ReportViwer(new FakeFileService());
           int BlockCount = viwer.PrepareDate(@"D:\Laboratory_works\Тестирование\File_test");
           Assert.That(BlockCount, Is.EqualTo(5));
        }
        [Test]
        public void PrepareDate_Path_ZiroNumber() //Stab
        {
            ReportViwer viwer = new ReportViwer(new FileService());
            int BlockCount = viwer.PrepareDate(@"D:\Laboratory_works\Тестирование\Filetest\");
            Assert.That(BlockCount, Is.EqualTo(0));
        }

        [Test]
        public void MergeTemporaryFiles_Path_FileComponent() //Stab
        {
            FileService fileService = new FileService();
            fileService.MergeTemporaryFiles(@"D:\Laboratory_works\Тестирование\File_test\");
            List<string> list = new List<string> {"Hello\r\n", "world", "this", "crazy\r\n", "File"};
            Assert.That(fileService.Get(), Is.EqualTo(list));
        }
        [Test]
        public void MergeTemporaryFiles_Path_CountDeleteFile() //Stab
        {
            //предв обраб

            DeleteFile deleteFile = new DeleteFile();
            FileService fileService = new FileService();
            fileService.MergeTemporaryFiles(@"D:\Laboratory_works\Тестирование\File_test\");
            Assert.That(fileService.Get_int(), Is.EqualTo(5));
        }
        [Test]
        public void MergeTemporaryFiles_Path_Get_BlockCount() //Stab
        {
            ReportViwer viwer = new ReportViwer(new FileService());
            int BlockCount = viwer.PrepareDate(@"D:\Laboratory_works\Тестирование\File_test\");
            Assert.That(BlockCount, Is.EqualTo(5));
        }
        [Test]
        public void MergeTemporaryFiles_Path_backup() //Stab
        {
            string PathInFaleForCreateAndWrite = @"D:\Laboratory_works\Тестирование\File_test\bacup.tmp";
            FileService fileService = new FileService();
            fileService.MergeTemporaryFiles(@"D:\Laboratory_works\Тестирование\File_test\");
            Assert.IsTrue(File.Exists(PathInFaleForCreateAndWrite));
        }

        [Test]
        public void PrepareDate_PathFale_Exception()
        {
            ReportViwer viwer = new ReportViwer(new FakeFileService());
            int BlockCount = viwer.GetBlockCount();
            Assert.Throws<NullReferenceException>(() => viwer.PrepareDate(@"D:\Laboratory_work"));
        }
        
        [Test]
        public void Test_interaction_ReportViverAndFakelass()
        {
            FakeFileService moq_fakeFile = new FakeFileService();
            ReportViwer viwer = new ReportViwer(moq_fakeFile);
            viwer.PrepareDate(@"D:\Laboratory_works\Тестирование\File_test");
            Assert.IsTrue(moq_fakeFile.Check_FakeFileService);
        }

        [Test]
        public void MergeTemporaryFilesOne_Path_FileComponent() //Stab
        {
            FileService fileService = new FileService();
            fileService.MergeTemporaryFilesOne(@"D:\Laboratory_works\Тестирование\File_test\");
            List<string> list = new List<string> { "Hello\r\n", "world", "this", "crazy\r\n", "File" };
            Assert.That(fileService.Get(), Is.EqualTo(list));
        }
        [Test]
        public void MergeTemporaryFilesOne_Path_CountDeleteFile() //Stab
        {
            DeleteFile deleteFile = new DeleteFile();
            FileService fileService = new FileService();
            fileService.MergeTemporaryFilesOne(@"D:\Laboratory_works\Тестирование\File_test\");
            Assert.That(fileService.Get_int(), Is.EqualTo(5));
        }
        [Test]
        public void MergeTemporaryFilesOne_Path_backup() //Stab
        {
            FileService fileService = new FileService();
            fileService.MergeTemporaryFilesOne(@"D:\Laboratory_works\Тестирование\File_test\");
            Assert.AreEqual("bacup.tmp", fileService.Get_stroka());
        }

    }   
}
