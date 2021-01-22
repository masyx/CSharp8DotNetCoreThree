using System;
using System.Collections.Generic;

namespace Packt.Shared
{
    public class ThingOfDefault
    {
        public int Population;
        public DateTime When;
        public string Name;
        public List<Person> People;

        public ThingOfDefault()
        {
            Population = default;
            When = default;
            Name = default;
            People = default;
        }
    }
}