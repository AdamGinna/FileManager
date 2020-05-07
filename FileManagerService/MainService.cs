using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceProcess;
using System.Threading.Tasks;
using FileManager;
using Microsoft.EntityFrameworkCore;
using SaveData;

namespace FileManagerService
{
    class MainService : ServiceBase
    {

        protected override void OnStart(string[] args)
        {
            //base.OnStart(args);
            Task.Run(() => CreateDataAsync());
        }

        public void OnStartTest(string[] args)
        {
            //base.OnStart(args);
           Task task = Task.Run(() => CreateDataAsync());
            task.Wait();
        }

        protected async System.Threading.Tasks.Task CreateDataAsync()
        {
  
            FileManager.FileManager manager = new FileManager.FileManager();
            manager.GetDiskData();
            DriveInfo[] drives = manager.Drives;
            List<FilesData> listFileData = new List<FilesData>(drives.Length);
            for(int i = 0; i<drives.Length; i++)
            {
               listFileData[i] = await manager.GetAllData(drives[i].Name);
            }
            Serialize(listFileData);
            FilesData Alldata = new FilesData();
            Alldata.Zero();
            foreach (FilesData data in listFileData)
            {
                Alldata += data;
            }
            Serialize(Alldata);
        }

        void Serialize(List<FilesData> data)
        {
            FileStream fs = new FileStream(@"Solution Item/DataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, data);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        void Serialize(FilesData data)
        {
            FileStream fs = new FileStream(@"Solution Item/AllDataFile.dat", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, data);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                Console.WriteLine("check ");

                fs.Close();
            }
        }

    }

}
