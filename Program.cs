using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileCleaner
{
    class Program
    {
        public static string rootPath = "";
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@"Copy this path to minimise typing:          C:\Users\TBG\Desktop");
                rootPath = FilePaths.SetRootPath(args);
                GetRootPath(args);


                Console.Clear();
                Console.Write($"Root path set to: {rootPath}.");


                Console.WriteLine("\n\nPress enter to start");
                Console.ReadLine();
                Console.Clear();

                RearrangeFiles();
            } while (!Input("Work on another file? <y/n>: ").ToLower().StartsWith("n"));
        }

        static void GetRootPath(string [] args)
        {
            while (!Directory.Exists(rootPath))
            {
                Console.Clear();
                Console.WriteLine("The folder you specified does not exist.\nPlease enter a folder path that exists...\n\n");
                rootPath = FilePaths.SetRootPath(args);
            }
        }

        private static void RearrangeFiles()
        {

            string DeepSearch = Input("Perform deep search? <y/n>");
            string[] Files;

            if (DeepSearch.ToLower().StartsWith("n"))
                Files = Directory.GetFiles(rootPath, "*", SearchOption.TopDirectoryOnly);
            else
                Files = Directory.GetFiles(rootPath, "*", SearchOption.AllDirectories);


            if (Files.Length ==  0)
            {
                Console.WriteLine("No files were found.");
            }

            foreach (var file in Files)
            {
                Console.WriteLine($"\n\nMoving {Path.GetFileName(file)}\n");
                FileProcessor.MoveFile(file, FilePaths.GetPath(file));
            }

            Console.WriteLine("\n\nDone. Press enter to exit...");
            Console.ReadLine();
        }

        static string Input(string Prompt = "")
        {
            Console.Write(Prompt);
            return Console.ReadLine();
        }

    }
}
