using System;
using System.IO;
using System.IO.Compression;
using System.Xml;

namespace WorkWithCompression
{
    class WorkWithCompression
    {
        static void Main(string[] args)
        {
            WorkWithCompressionMethod();
        }

        static void WorkWithCompressionMethod(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";

            string[] pilotCallSigns = new string[] {
                "Husker", "Starbuck", "Apollo", "Boomer",
                "Bulldog", "Athena", "Helo", "Racetrack"};

            // compress xml output
            string filePath = Path.Combine(Environment.CurrentDirectory, $"streams.{fileExt}");

            FileStream file = File.Create(filePath);

            Stream compressor;

            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }

            using (compressor)
            {
                using (XmlWriter xmlGzip = XmlWriter.Create(compressor))
                {
                    xmlGzip.WriteStartDocument();
                    xmlGzip.WriteStartElement("pilotCallSigns");

                    foreach (var callSign in pilotCallSigns)
                    {
                        xmlGzip.WriteElementString("pilotCallSign", callSign);
                    }

                    // the normal call to xmlGzip.WriteEndElement is not necessary
                    // because when XmlWriter disposes, it will automatically end
                    // any elements of any depth
                }
            } // also closes the underlying stream

            // output all the contents of the compresed file
            Console.WriteLine($"{filePath} contains {new FileInfo(filePath).Length:N0} bytes");
            Console.WriteLine("The compressed contents");
            Console.WriteLine(File.ReadAllText(filePath));

            // read a compressed file
            Console.WriteLine("Reading a compressed XML file");
            file = File.Open(filePath, FileMode.Open);

            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }
            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read()) //read the next XML node
                    {
                        // check if we are on a element node called pilotCallSign
                        if (reader.NodeType == XmlNodeType.Element &&
                            reader.Name == "pilotCallSign")
                        {
                            reader.Read(); // move to the next inside element
                            Console.WriteLine($"{reader.Value}");
                        }
                    }
                }

            }
        }
    }
}
