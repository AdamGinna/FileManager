using NUnit.Framework;
using FileManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FileManager.Tests
{
    [TestFixture()]
    public class FileManagerTests
    {
        [Test()]
        public async Task FileManagerTestAsync()
        {
            FileManager man = new FileManager();
            man.Path = @"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy";
            FilesData data = await Task.Run(() => man.GetAllData());
            Assert.AreEqual(18, data.Files);
            Assert.AreEqual(6, data.ImageFiles);
            Assert.AreEqual(2, data.AudioFiles);
            Assert.AreEqual(17633248 * 2, data.ArchBytes);
        }

        [Test()]
        public void FileManagerTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetFilesDataTest()
        {
            FilesData data = FileManager.GetFilesData(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            Assert.AreEqual(data.Files, 11);
            Assert.AreEqual(data.AudioFiles, 1);
            Assert.AreEqual(data.ImageFiles, 4);
            Assert.AreEqual(data.DocumentFiles, 3);
            Assert.AreEqual(data.ArchFiles, 1);
            Assert.AreEqual(data.FilmFiles, 1);
        }

        [Test()]
        public async Task GetAllDataTestAsync()
        {
            FileManager man = new FileManager();
            FilesData data = await Task.Run(() => man.GetAllData());
            Console.WriteLine(data.Files);

        }

        [Test()]
        public void GetDiskDataTest()
        {
            FileManager man = new FileManager(); 
            man.GetDiskData();
            Assert.IsNotNull(man.Drives);
        }
    }
}