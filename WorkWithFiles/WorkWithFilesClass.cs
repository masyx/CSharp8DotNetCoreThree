using System;
using System.IO;

namespace WorkWithFiles
{
    class WorkWithFilesClass
    {
        static void Main(string[] args)
        {
            WorkWithFilesMethod();
        }

        static void WorkWithFilesMethod()
        {
            // define a directory path to output files
            // starting in the user's
            string dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "Code", "Chapter09", "OutputFiles");

            Directory.CreateDirectory(dir);

            // define file path
            string textFile = Path.Combine(dir, "Dummy.txt");
            string backupFile = Path.Combine(dir, "Dummy.bak");

            Console.WriteLine($"Working with {textFile}");
            Console.WriteLine($"Does it exists? {File.Exists(textFile)}");

            // create a new text file and write a line to it
            StreamWriter textWriter = File.CreateText(textFile);
            textWriter.WriteLine("Hello, C#");
            textWriter.Close();   
            Console.WriteLine($"Does it exists? {File.Exists(textFile)}");

            // copy the file and owerwrite if it already exists
            File.Copy(sourceFileName: textFile, destFileName: backupFile, overwrite: true);

            Console.WriteLine($"Does {backupFile} file exists? {File.Exists(backupFile)}");

            Console.WriteLine("Confirm the files exsit and press ENTER.");
            Console.ReadLine();

            // delete file
            File.Delete(textFile);
            Console.WriteLine($"Does {textFile} file exists? {File.Exists(textFile)}");

            // read from the text file backup
            Console.WriteLine($"Reading from {backupFile}");
            StreamReader textReader = File.OpenText(backupFile);
            Console.WriteLine(textReader.ReadToEnd());
            textReader.Close();



            // managing paths
            Console.WriteLine();
            Console.WriteLine($"Folder name: {Path.GetDirectoryName(textFile)}");
            Console.WriteLine($"File name: {Path.GetFileName(textFile)}");
            Console.WriteLine($"File name without extension: {Path.GetFileNameWithoutExtension(textFile)}");
            Console.WriteLine($"File extension: {Path.GetExtension(textFile)}");
            Console.WriteLine($"Random file: {Path.GetRandomFileName()}");
            Console.WriteLine($"Temporary file: {Path.GetTempFileName()}");



            // getting file info
            Console.WriteLine();
            FileInfo backupInfo = new FileInfo(backupFile);
            Console.WriteLine($"{backupFile}");
            Console.WriteLine($"Contains {backupInfo.Length} bytes");
            Console.WriteLine($"Last accessed {backupInfo.LastAccessTime}");
            Console.WriteLine($"Has readonly set to {backupInfo.IsReadOnly}");

        }
    }
}
