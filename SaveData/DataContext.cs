using FileManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace SaveData
{
    public class DataContext : DbContext
    {
        public DbSet<DataSet> SavedDataFiles { get; set; }
        public DbSet<DataSetDrives> SavedDataDrives { get; set; }
        public DataContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite(@"Data Source=c:\FileManager.db");

        public static void SaveDataDrives(List<DataSet> dataList)
        {
            DataContext db = new DataContext();
            DataSetDrives setList = new DataSetDrives();
            setList.Data = dataList;
            setList.Date = DateTime.Now;
            db.SavedDataDrives.Add(setList);
            db.SaveChanges();

        }

        public static void SaveDataAll(FilesData data)
        {
            DataContext db = new DataContext();
            DataSet set = new DataSet();
            set.Data = data;
            set.Date = DateTime.Now;
            set.Name = "All";
            db.SavedDataFiles.Add(set);
            db.SaveChanges();
        }

    }

    public class DataSet
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public FilesData Data { get; set; }
        public string Name { get; set; }
    }

    public class DataSetDrives
    {
        [Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public List<DataSet> Data { get; set; }
    }
}
