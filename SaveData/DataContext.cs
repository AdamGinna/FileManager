using FileManager;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

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


        public static FilesData LoadDataAll()
        {
            DataContext db = new DataContext();
            DataSet result = db.SavedDataFiles.Include(t => t.Data).First();
            return result.Data;
        }

        public static List<DataSet> LoadDataDrives()
        {
            DataContext db = new DataContext();
            DataSetDrives setList = db.SavedDataDrives.Include(t => t.Data).ThenInclude(t => t.Data).OrderByDescending(t => t.Date).First(); 
            return setList.Data;
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
