using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCleaner
{
    static class Logger
    {
        static string OriginalFile { get; set; }
        static string NewFile { get; set; }

        public static void Log(string Original, string New)
        {
            OriginalFile = Original;
            NewFile = New;
            Console.WriteLine($"Moved {Original} to {New}.");
        }
    }
}
