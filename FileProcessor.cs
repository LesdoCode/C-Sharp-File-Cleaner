using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileCleaner
{
    public static class FileProcessor
    {
        public static void MoveFile(string _FileDir, string _DestinationDir)
        {
            string Extension;
            if (Path.HasExtension(_FileDir))
                Extension = (Path.GetExtension(_FileDir)).Remove(0, 1);
            else
                Extension = "";
            string FolderName = Path.Combine(_DestinationDir, $"{Extension} files");
            string NewPath = Path.Combine(FolderName, Path.GetFileName(_FileDir));


            if (!Directory.Exists(FolderName))
            {
                Console.WriteLine($"Creating dir {FolderName}");
                Directory.CreateDirectory(FolderName);
            }
            if (File.Exists(NewPath))
            {
                int count = 0;
                do
                {
                    NewPath = Path.Combine(FolderName, $"{Path.GetFileNameWithoutExtension(_FileDir)} {count}{Path.GetExtension(_FileDir)}");
                    count++;

                } while (File.Exists(NewPath));
            }

            Directory.Move(_FileDir, NewPath);
            Logger.Log(_FileDir, NewPath);
            //System.IO.IOException

        }
    }
}
