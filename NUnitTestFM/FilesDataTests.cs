using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FileManager;
using System.IO;

namespace NUnitTestFM
{
    [TestFixture()]
    class FilesDataTests
    {
        [Test()]
        public void FilesDataTest()
        {
            FilesData data = new FilesData();
            DirectoryInfo dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");//C:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy\
            Assert.IsTrue(dir.Exists);
            data.Dir = dir;//C:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy\
            Assert.IsNotNull(data.Dir);

        }
        [Test()]
        public void FilesDataTestNoDirectory()
        {
            FilesData data = new FilesData();
            Assert.Throws<DirectoryNotFoundException>(delegate { data.Dir = new DirectoryInfo("FolderTestowy2"); data.Start(); }, "Direction exist");

        }
        [Test()]
        public void FilesDataTestFiles()
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data.Start();
            Assert.AreEqual(data.Files, 11);
            Assert.AreEqual(data.AudioFiles, 1);
            Assert.AreEqual(data.ImageFiles, 4);
            Assert.AreEqual(data.DocumentFiles, 3);
            Assert.AreEqual(data.ArchFiles, 1);
            Assert.AreEqual(data.FilmFiles, 1);
        }

        [Test()]
        public void FilesDataTestBytes()
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data.Start();
            Assert.AreEqual(data.Bytes, 60506485);
            Assert.AreEqual(data.AudioBytes, 6278839);
            Assert.AreEqual(data.ImageBytes, 409175);
            Assert.AreEqual(data.DocumentBytes, 2796882);
            Assert.AreEqual(data.ArchBytes, 17633248);
            Assert.AreEqual(data.FilmBytes, 33386334);
        }

        [Test()]
        public void FilesDataTestAdd()
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data.Start();
            FilesData data2 = new FilesData();
            data2.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data2.Start();
            FilesData data3 = data + data2;
            Assert.AreEqual(data.Files + data2.Files, data3.Files);
            Assert.AreEqual(data.AudioFiles+data2.AudioFiles, data3.AudioFiles);
            Assert.AreEqual(data.ImageFiles+data2.ImageFiles, data3.ImageFiles);
            Assert.AreEqual(data.DocumentFiles+data2.DocumentFiles, data3.DocumentFiles);
            Assert.AreEqual(data.ArchFiles+data2.ArchFiles, data3.ArchFiles);
            Assert.AreEqual(data.FilmFiles+data2.FilmFiles, data3.FilmFiles);
            Assert.AreEqual(data.Bytes + data2.Bytes, data3.Bytes);
            Assert.AreEqual(data.AudioBytes + data2.AudioBytes, data3.AudioBytes);
            Assert.AreEqual(data.ImageBytes + data2.ImageBytes, data3.ImageBytes);
            Assert.AreEqual(data.DocumentBytes + data2.DocumentBytes, data3.DocumentBytes);
            Assert.AreEqual(data.ArchBytes + data2.ArchBytes, data3.ArchBytes);
            Assert.AreEqual(data.FilmBytes + data2.FilmBytes, data3.FilmBytes);
        }

    }
}
