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



        ulong _files;
        ulong Files { get => _files; }
        ulong _bytes;
        ulong Bytes { get => _bytes; }

        ulong _imageFiles;
        ulong ImageFiles { get => _imageFiles; }
        ulong _imageBytes;
        ulong ImageBytes { get => _imageBytes; }

        ulong _audioFiles;
        ulong AudioFiles { get => _audioFiles; }
        ulong _audioBytes;
        ulong AudioBytes { get => _audioBytes; }

        ulong _filmFiles;
        ulong FilmFiles { get => _filmFiles; }
        ulong _filmBytes;
        ulong FilmBytes { get => _filmBytes; }

        ulong _documentFiles;
        ulong DocumentFiles { get => _documentFiles; }
        ulong _documentBytes;
        ulong DocumentBytes { get => _documentBytes; }

        ulong _archFiles;
        ulong ArchFiles { get => _archFiles; }
        ulong _archBytes;
        ulong ArchBytes { get => _archBytes; }



        public DirectoryInfo Dir
        {
            get => Dir;
            set
            {
                if (value.Exists)
                {
                    SaveData(value);
                    // zerowanie danych 
                    Dir = value;
                }
                else
                    throw new DirectoryNotFoundException();
            }
        }


        private void SaveData(DirectoryInfo dir)
        {
            var fileList = dir.GetFiles();
            foreach (FileInfo file in fileList)
            {
                _files++;
                _bytes += (ulong)file.Length;
                string extension = file.Extension;
                if (Array.Exists(ImageFormat, element => element == extension))
                {
                    _imageBytes += (ulong)file.Length;
                    _imageFiles++;
                }
                else if (Array.Exists(DocumentFormat, element => element == extension))
                {
                    _documentBytes += (ulong)file.Length;
                    _documentFiles++;
                }
                else if (Array.Exists(AudioFormat, element => element == extension))
                {
                    _audioBytes += (ulong)file.Length;
                    _audioFiles++;
                }
                else if (Array.Exists(ArchFormat, element => element == extension))
                {
                    _archBytes += (ulong)file.Length;
                    _archFiles++;
                }
                else if (Array.Exists(FilmFormat, element => element == extension))
                {
                    _filmBytes += (ulong)file.Length;
                    _filmFiles++;
                }
            }
        }


        static public FilesData operator +(FilesData a, FilesData b)
        {
            a._files += b._files;
            a._bytes += b._bytes;
            a._imageFiles += b._imageFiles;
            a._imageBytes += b._imageBytes;
            a._audioFiles += b._audioFiles;
            a._audioBytes += b._audioBytes;
            a._filmFiles += b._filmFiles;
            a._filmBytes += b._filmBytes;
            a._documentFiles += b._documentFiles;
            a._documentBytes += b._documentBytes;
            a._archFiles += b._archFiles;
            a._archBytes += b._archBytes;
            return a;
        }
    }
}
