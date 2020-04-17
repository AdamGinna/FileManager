using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileManager
{
    public struct FilesData
    {
        static private readonly string[] ImageFormat = { ".jpg", ".png", ".gif", ".tiff", ".bmp", ".ppm", ".pgm", ".pbm", ".pnm", ".heif", ".hdr", ".svg", ".cdr", ".eps", ".ai", ".swf", ".psd" };
        static private readonly string[] DocumentFormat = { ".pdf", ".doc", ".docm", ".docx", ".dot", ".dotx", ".txt", ".fb2", ".tex", ".mcw", ".odt", ".ott", ".pages", ".rtf", ".swt", ".sxw", ".wps", ".wpt", ".wri", ".abw", ".zabw", ".123", ".csv", ".et", ".ett", ".numbers", ".ods", ".ots", ".stc", ".sxc", ".sxc", ".wk1", ".wk2", ".wk3", ".wk4", ".wk4", ".xlw", ".xlr", ".xls", ".xla", ".xlt", ".xlk", ".xlsx", ".xlsm", ".xlsb", ".xltx", ".xlam", ".xltm", ".key", ".odp", ".otp", ".pps", ".ppt", ".pptx", ".sti", ".sxi" };
        static private readonly string[] AudioFormat = { ".wav", ".aif", ".aiff", ".aifc", ".aifr", ".flac", ".wv", ".ra", ".rm", ".rf", ".mp2", ".wma", ".ape", ".apl", ".tta", ".tak", ".shn", ".mlp", ".mpg", ".mpe", ".mpeg", ".mpeg2", ".mpc", ".mp3", ".mp3pro", ".m4a", ".ogg", ".oga" };
        static private readonly string[] ArchFormat = { ".zip", ".rar", ".7z", ".tar", ".cab", ".bzip2", ".arj", };
        static private readonly string[] FilmFormat = { ".3gp", ".asf", ".avi", ",dv", ".dvd", ".flv", ".m2ts", ".mkv", ".mov", ".mp4", ".mpg", ".ogg", ".smv", ".ts", ".svcd", ".wmv", ".vcd" };



        public ulong Files {
            get;
            private set; }

        public ulong Bytes { get; private set; }

        public ulong ImageFiles { get; private set; }
        public ulong ImageBytes { get; private set; }

        public ulong AudioFiles { get; private set; }
        public ulong AudioBytes { get; private set; }

        public ulong FilmFiles { get; private set; }
        public ulong FilmBytes { get; private set; }

        public ulong DocumentFiles { get; private set; }
        public ulong DocumentBytes { get; private set; }

        public ulong ArchFiles { get; private set; }
        public ulong ArchBytes { get; private set; }



        public DirectoryInfo Dir
        {
            get;
            set;
        }

        public void Zero()
        {
                Files = 0;
                Bytes = 0;
                ImageFiles = 0;
                ImageBytes = 0;
                AudioFiles = 0;
                AudioBytes = 0;
                FilmFiles = 0;
                FilmBytes = 0;
                DocumentFiles = 0;
                DocumentBytes = 0;
                ArchFiles = 0;
                ArchBytes = 0;
        }

        public void Start()
        {
            if (Dir.Exists)
            {
                Zero();
                SaveData(Dir);
                // zerowanie danych 
            }
            else
            {
                throw new DirectoryNotFoundException();
            }
        }


        private void SaveData(DirectoryInfo dir)
        {
            FileInfo[] fileList;
            try
            {
                fileList = dir.GetFiles();
            }catch
            {
                fileList = new FileInfo[0];
            }
            foreach (FileInfo file in fileList)
            {
                Files++;
                Bytes += (ulong)file.Length;
                string extension = file.Extension;
                if (Array.Exists(ImageFormat, element => element == extension))
                {
                    ImageBytes += (ulong)file.Length;
                    ImageFiles++;
                }
                else if (Array.Exists(DocumentFormat, element => element == extension))
                {
                    DocumentBytes += (ulong)file.Length;
                    DocumentFiles++;
                }
                else if (Array.Exists(AudioFormat, element => element == extension))
                {
                    AudioBytes += (ulong)file.Length;
                    AudioFiles++;
                }
                else if (Array.Exists(ArchFormat, element => element == extension))
                {
                    ArchBytes += (ulong)file.Length;
                    ArchFiles++;
                }
                else if (Array.Exists(FilmFormat, element => element == extension))
                {
                    FilmBytes += (ulong)file.Length;
                    FilmFiles++;
                }
            }
        }


        static public FilesData operator +(FilesData a, FilesData b)
        {
            a.Files += b.Files;
            a.Bytes += b.Bytes;
            a.ImageFiles += b.ImageFiles;
            a.ImageBytes += b.ImageBytes;
            a.AudioFiles += b.AudioFiles;
            a.AudioBytes += b.AudioBytes;
            a.FilmFiles += b.FilmFiles;
            a.FilmBytes += b.FilmBytes;
            a.DocumentFiles += b.DocumentFiles;
            a.DocumentBytes += b.DocumentBytes;
            a.ArchFiles += b.ArchFiles;
            a.ArchBytes += b.ArchBytes;
            return a;
        }
    }
}
