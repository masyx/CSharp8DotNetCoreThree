#nullable enable
using System;

namespace NullHandling
{
    class NullHandling
    {
        static void Main(string[] args)
        {
            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = "London";
            address.Region = null;
        }
    }

    class Address
    {
        public string? Building;
        public string Street = string.Empty;
        public string City = string.Empty;
        public string Region = string.Empty;
    }
}
