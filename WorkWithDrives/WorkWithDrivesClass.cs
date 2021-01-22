using System;
using static System.Console;
using  System.IO;

namespace WorkWithDrives
{
    class ProgramWorkWithDrivesClass
    {
        static void Main(string[] args)
        {
            WorkWithDrives();
        }

        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
              "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine(
                      "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                      drive.Name, drive.DriveType, drive.DriveFormat,
                      drive.TotalSize, drive.AvailableFreeSpace);
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }
    }
}
