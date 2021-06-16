using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FileCleaner
{
    class FilePaths
    {
        static string OtherItemsPath = @"C:\Users\TBG\Desktop\My Files\";


        static string Images = @"C:\Users\TBG\Pictures";
        static string Videos = @"C:\Users\TBG\Videos";
        static string Audio = @"C:\Users\TBG\Music";
        static string Documents = @"C:\Users\TBG\Documents";

        static string Compressed = Path.Combine(OtherItemsPath, @"Compressed");
        static string Executable = Path.Combine(OtherItemsPath, @"Applications");
        static string Code = Path.Combine(OtherItemsPath, @"Code");
        static string Database = Path.Combine(OtherItemsPath, @"Database");
        static string UnknownFiles = Path.Combine(OtherItemsPath, @"Unknown");
        static string Torrent = Path.Combine(OtherItemsPath, @"Torrent");

        private static Dictionary<string, string> MediaFormats = new Dictionary<string, string>
        { 
            {".png", Images },
            {".pcd", Images },
            {".fpx", Images },
            {".jpg", Images },
            {".tiff", Images },
            {".bmp", Images },
            {".webp", Images },
            {".jpeg", Images },

            {".m4a", Audio },
            {".flac", Audio},
            {".mp3", Audio },
            {".wav", Audio },
            {".wma", Audio },
            {".aac", Audio },

            {".mp4", Videos },
            {".mov", Videos },
            {".wmv", Videos },
            {".avi", Videos },
            {".avchd", Videos},
            {".flv", Videos },
            {".f4v", Videos },
            {".swf", Videos },
            {".mkv", Videos },
            {".webm", Videos },
            {".mpeg-2", Videos},

            {".doc", Documents },
            {".docx", Documents},
            {".odt", Documents },
            {".pdf", Documents },
            {".xls", Documents },
            {".xlsx", Documents},
            {".ppt", Documents },
            {".pptx", Documents },
            {".txt", Documents},

            {".exe", Executable },
            {".msi", Executable },

            {".py", Code },
            {".cs", Code },
            {".cpp", Code },
            {".js", Code },
            {".java", Code},
            {".html", Code },
            {".htm", Code },
            {".xml", Code },
            {".xaml", Code },
            {".csv", Code },

            {".accdt", Database },
            {".mdb", Database },
            {".mda", Database },
            {".sql", Database },
            {".db", Database },

            {".rar", Compressed },
            {".zip", Compressed },

            {".torrent", Torrent },
        };

        public static string GetPath(string _FilePath)
        {
            string Extention = Path.GetExtension(_FilePath).ToLower();
            
            if (MediaFormats.ContainsKey(Extention))
                return MediaFormats[Extention];
            else
                return UnknownFiles;
        }

        public static string SetRootPath(string[] _args)
        {
            if (_args.Length > 0)
            {
                return _args[0];
            }
            else
            {
                Console.Write("Root path: ");
                return Console.ReadLine();
            }
        }

    }
}
