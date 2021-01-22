using System;
using System.IO;

namespace WorkWithDirectories
{
    class WorkWithDirectoriesClass
    {
        static void Main(string[] args)
        {
            WorkWithDirectoriesMethod();
        }

        static void WorkWithDirectoriesMethod()
        {
            // define a directory path for a new folder
            // starting in the user's folder
            var newFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Code", "Chapter09", "NewFolder");

            Console.WriteLine($"Working with {newFolder}");

            // chekc if NewFolder exists
            Console.WriteLine($"Does NewFolder exist? {Directory.Exists(newFolder)}");

            // creating it
            Directory.CreateDirectory(newFolder);
            Console.WriteLine($"Does NewFolder exist? {Directory.Exists(newFolder)}");

            Console.WriteLine("Confirm the directory exists and then press ENTER");
            Console.ReadLine();

            //delete derectory
            Console.WriteLine("Deleting directory");
            Directory.Delete(newFolder, recursive: true);
            Console.WriteLine($"Does NewFolder exist? {Directory.Exists(newFolder)}");
        }
    }
}
