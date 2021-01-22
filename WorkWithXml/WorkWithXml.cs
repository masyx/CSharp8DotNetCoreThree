using System;
using System.IO;
using System.Xml;

namespace WorkWithXml
{
    class WorkWithXml
    {
        static void Main(string[] args)
        {
            WorkWithXmlMethod();
        }

        static void WorkWithXmlMethod()
        {
            string[] pilotCallSigns = new string[] {
                "Husker", "Starbuck", "Apollo", "Boomer",
                "Bulldog", "Athena", "Helo", "Racetrack"};

            // define a file to write to
            string xmlFile = Path.Combine(Environment.CurrentDirectory, "streams.xml");

            // create a file stream
            using (FileStream xmlFileStream = File.Create(xmlFile))
            {
                // wrap the file stream in a Xml writer helper
                // and automatically indent nested elements
                using (XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true }))
                {
                    try
                    {
                        // write the xml declaration
                        xml.WriteStartElement("pilotCallSigns");

                        // enumerate the strings writing each one to the stream
                        foreach (var callSign in pilotCallSigns)
                        {
                            xml.WriteElementString("pilotCallSign", callSign);
                        }

                        // write a close root element
                        xml.WriteEndElement();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{ex.GetType()} says: \"{ex.Message}\"");
                    }
                }
            }

            // output all the contents of the file
            Console.WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length:N0} bytes");
            Console.WriteLine(File.ReadAllText(xmlFile));
        }
    }
}
