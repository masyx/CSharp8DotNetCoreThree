using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public partial class Person : object
    {
        public const string Species = "Homo Sapien";
        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAncientWorld FavoriteAncientWonder;
        public WondersOfTheAncientWorld BucketList;
        public List<Person> Children = new List<Person>();

        public Person()
        {
            Name = "Unknown";
            Instantiated = DateTime.Now;
        }

        public Person(string name, string homePlanet)
        {
            Name = name;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }

        public (string, int) GetFruite()
        {
            return ("Apples", 5);
        }

    }
}
