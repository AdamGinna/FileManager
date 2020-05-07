using FileManager;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SaveData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SaveData.Tests
{
    [TestFixture()]
    class SaveDataTest
    {
        /// <summary>
        /// stworzenie metody do zapisywania 
        /// testy tej metody 
        /// dodanie metody do serwisu
        /// dodawanie metody do wpf
        /// </summary>
        [Test()]
        public void SaveTest()
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data.Start();
            DataContext.SaveDataAll(data);
            
        }

        [Test()]
        public void SaveTest2()
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(@"c:\Users\Adam\source\repos\FileManager\NUnitTestFM\FolderTestowy");
            data.Start();
            var db = new SaveData.DataContext();
            List<DataSet> drives = new List<DataSet>();
            DataSet set1 = new DataSet();
            set1.Data = data;
            set1.Name = @"C:\";
            set1.Date = DateTime.Now;
            drives.Add(set1);
            DataContext.SaveDataDrives(drives);
        }

        [Test()]
        public void LoadTest()
        {
            var db = new SaveData.DataContext();

            foreach (SaveData.DataSet save in db.SavedDataFiles.ToList())
            {
                Console.WriteLine(save.Name);
            }

            Assert.IsNotNull(db.SavedDataFiles);
            Assert.IsNotNull(db.SavedDataDrives);

        }
    }
}
