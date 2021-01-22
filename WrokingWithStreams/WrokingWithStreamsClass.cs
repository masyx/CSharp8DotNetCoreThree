using System;
using System.IO;
using System.Xml;

namespace WrokingWithStreams
{
    class WrokingWithStreamsClass
    {
        static void Main(string[] args)
        {
            WorkingWithText();
        }

        static void WorkingWithText()
        {
            string[] pilotCallSigns = new string[] {
                "Husker", "Starbuck", "Apollo", "Boomer",
                "Bulldog", "Athena", "Helo", "Racetrack"};

            // define a file to write to
            var textFile = Path.Combine(Environment.CurrentDirectory, "steams.txt");

            // create a text file and return a helper writer
            StreamWriter text = File.CreateText(textFile);

            foreach(string sign in pilotCallSigns)
            {
                text.WriteLine(sign);
            }

            text.Close(); // realease resources

            // output the contents of the file
            Console.WriteLine($"\"{textFile}\" contains {new FileInfo(textFile).Length} bytes");

            Console.WriteLine(File.ReadAllText(textFile));
        }
    }
}
