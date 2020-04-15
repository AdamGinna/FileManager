using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

/// TO DO: 
/// 1. poprawić wątki i sprawdzic czy nie będzie ich za dużo DFS
/// 2. GetDiskDAta() poczytać zaimplemtentoawc Drives.Name 
/// 3. zrobić testy dla FileManager, DataManager
/// 4. aplikacja lub serializacja danych 

namespace FileManager
{
    public class FileManager
    {
        public string Path { get; set; }
        public DriveInfo[] Drives { get; private set; }

        public FileManager() => Path = "c:";
        public FileManager(string path) => Path = path;

        static public FilesData GetFilesData(string path)
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(path);
            data.Start();
            return data;
        }


        public async Task<FilesData> GetAllData(string root)   // łapać jeśli root nie istnieje
        {
            // https://stackoverflow.com/questions/4513438/c-sharp-recursion-depth-how-deep-can-you-go
            //wykorzystać wątki 
            Path = root;
            DirectoryInfo dir = new DirectoryInfo(root);
            if(!dir.Exists)
            {
                throw new DirectoryNotFoundException();
            }
            FilesData data = new FilesData();
            FilesData firstData = await Task.Run(()=>GetFilesData(root));
        //    ///     List<Task<int>> tasks = new List<Task<int>>();
        //    for (int ctr = 1; ctr <= 10; ctr++)
        //    {
        //        int baseValue = ctr;
        //        tasks.Add(Task.Factory.StartNew((b) => {
        //            int i = (int)b;
        //            return i * i;
        //        }, baseValue));
        //    }
        //    var continuation = Task.WhenAll(tasks);

        //    long sum = 0;
        //    for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
        //    {
        //        Console.Write("{0} {1} ", continuation.Result[ctr],
        //                      ctr == continuation.Result.Length - 1 ? "=" : "+");
        //        sum += continuation.Result[ctr];
        //    }
        //    Console.WriteLine(sum);
        //}
            ///
            foreach(DirectoryInfo directory in dir.GetDirectories())
            {
                data += await Task.Run(() => GetFilesData(directory.FullName));
            }
            data += firstData;
            foreach(DirectoryInfo directory in dir.GetDirectories())
            {
                data += await GetAllData(directory.Name);
            }
            return data;
            // przeszukiwanie w głąb (DFS) dodawanie danych i zwracanie sumy (czy nie będzie problemu z rekuręcją) 
        }

        public void GetDiskData()
        {
            Drives = DriveInfo.GetDrives();
            
            // inforamcje o dysku (poszukać co można zrobić)
        }

    }

}
