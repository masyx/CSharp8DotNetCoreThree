using System;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
    class WorkingWithFileSystemsClass
    {
        static void Main(string[] args)
        {
            OutputFileSystemInfo();
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0, -33} {1}", "Path.PathSeparator", Path.PathSeparator);
            WriteLine("{0, -33} {1}", "Path.DirectorySeparatorChar", Path.DirectorySeparatorChar);
            WriteLine("{0, -33} {1}", "Directory.GetCurrentDirectory()", Directory.GetCurrentDirectory());
            WriteLine("{0, -33} {1}", "Environment.CurrentDirectory", Environment.CurrentDirectory);
            WriteLine("{0, -33} {1}", "Environment.SystemDirectory", Environment.SystemDirectory);
            WriteLine("{0, -33} {1}", "Path.GetTempPath()", Path.GetTempPath());


            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("{0,-33} {1}", "  .System)", GetFolderPath(SpecialFolder.System));
            WriteLine("{0,-33} {1}", "  .ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("{0,-33} {1}", "  .MyDocuments)", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("{0,-33} {1}", "  .Personal)", GetFolderPath(SpecialFolder.Personal));
        }
    }
}
