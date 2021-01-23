using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithSerialization
{
    class WorkingWithSerialization
    {
        static async Task Main(string[] args)
        {
            //SerializeAndDeseializeObjectGraphXML();

            await SerializeAndDeseializeObjectGraphJSON();
        }

        static void SerializeAndDeseializeObjectGraphXML()
        {
            // create an object graph
            var people = new List<Person>
            {
                new Person(3000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14)
                },

                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1969, 11, 23)
                },

                new Person(2000M)
                {
                    FirstName = "Charlie",
                    LastName = "Cox",
                    DateOfBirth = new DateTime(1984, 5, 4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth = new DateTime(2000, 7, 12)
                        }
                    }
                }
            };

            // create object that will format a List of Persons as XML
            var xs = new XmlSerializer(typeof(List<Person>));

            //create a file to write to
            string path = Path.Combine(Environment.CurrentDirectory, "people.xml");

            using (var stream = File.Create(path))//new StreamWriter(path) - this work as well ¯\_(ツ)_/¯
            {
                xs.Serialize(stream, people);
            }

            Console.WriteLine($"Written {new FileInfo(path).Length} bytes of XML to {path}");
            Console.WriteLine();

            // display serialized object
            Console.WriteLine(File.ReadAllText(path));
            Console.WriteLine();


            // DESERIALIZE OBJECT GRAPH
            using (var xmlLoad = File.Open(path, FileMode.Open))
            {
                // deserialize and cast the object graph into List of Person
                List<Person> loadedPeople = (List<Person>)xs.Deserialize(xmlLoad);

                foreach (var item in loadedPeople)
                {
                    Console.WriteLine($"{item.LastName} has {item.Children.Count} children.");
                }
            }
        }

        static async Task SerializeAndDeseializeObjectGraphJSON()
        {
            // create an object graph
            var people = new List<Person>
            {
                new Person(3000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new DateTime(1974, 3, 14)
                },

                new Person(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new DateTime(1969, 11, 23)
                },

                new Person(2000M)
                {
                    FirstName = "Charlie",
                    LastName = "Cox",
                    DateOfBirth = new DateTime(1984, 5, 4),
                    Children = new HashSet<Person>
                    {
                        new Person(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth = new DateTime(2000, 7, 12)
                        }
                    }
                }
            };

            // create a file to write to
            string jsonPath = Path.Combine(Environment.CurrentDirectory, "people.json");

            using(StreamWriter jsonStream = File.CreateText(jsonPath))
            {
                // create an object that will format as JSON
                var jss = new Newtonsoft.Json.JsonSerializer();

                // serialize the object graph into a json string
                jss.Serialize(jsonStream, people);
            }

            Console.WriteLine();
            Console.WriteLine($"Written {new FileInfo(jsonPath).Length} bytes of JSON to {jsonPath}");

            // display the serialized object graph
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText(jsonPath));


            using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
            {
                // deserialize object graph into a List of Person
                var loadedPeople = (List<Person>) await System.Text.Json.JsonSerializer.
                    DeserializeAsync(utf8Json: jsonLoad, returnType: typeof(List<Person>));

                Console.WriteLine();
                foreach (var person in loadedPeople)
                {
                    Console.WriteLine("{0} has {1} {2}",
                        person.LastName, person.Children?.Count >= 1 ? person.Children?.Count : 0,
                        person.Children?.Count == 1 ? "child" : "children");
                }
            }
            
        }
    }

    public class Person
    {
        public Person()
        {

        }
        public Person(decimal salary)
        {
            Salary = salary;
        }

        protected decimal Salary { get; set; }
        [XmlAttribute("fname")]
        public string FirstName { get; set; }
        [XmlAttribute("lname")]
        public string LastName { get; set; }
        [XmlAttribute("dob")]
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person> Children { get; set; }
    }
}
