using System;
using System.IO;

/// TO DO: 
/// 1. GetAllData()  główna funkcja 
/// 2. GetDiskDAta() poczytać zaimplemtentoawc
/// 3. zrobić testy dla FileManager, DataManager
/// 4. aplikacja lub serializacja danych 

namespace FileManager
{
    public class FileManager
    {
        public string Path { get; set; }
        public FileManager() => Path = "c:";
        public FileManager(string path) => Path = path;

        public FilesData GetFilesData(string path)
        {
            FilesData data = new FilesData();
            data.Dir = new DirectoryInfo(path);
            return data;
        }

        public FilesData GetAllData(string root)   // łapać jeśli root nie istnieje
        {
            // https://stackoverflow.com/questions/4513438/c-sharp-recursion-depth-how-deep-can-you-go
            //wykorzystać wątki 
            throw new NotImplementedException(); // przeszukiwanie w głąb (DFS) dodawanie danych i zwracanie sumy (czy nie będzie problemu z rekuręcją) 
        }

        public void GetDiskData()
        {
            throw new NotImplementedException(); // inforamcje o dysku (poszukać co można zrobić)
        }

    }

}
