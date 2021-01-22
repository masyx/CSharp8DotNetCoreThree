using System;

namespace Packt.Shared
{
    public partial class Person
    {
        // a property defined using C# 1-5 syntax
        public string Origin
        {
            get
            {
                return $"{Name} was born on {HomePlanet}";
            }
        }

        // a property defined using C# 6+ lambda expression syntax
        public string Greeting => $"{Name} says Hello!";

        public int Age => DateTime.Today.Year - DateOfBirth.Year;

        public string FavoriteIceCream { get; set; }

        private string favoritePrimaryColor;
        public string FavoritePrimaryColor
        {
            get => favoritePrimaryColor;
            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favoritePrimaryColor = value;
                        break;
                    default:
                        throw new ArgumentException($"{value} is not a primary color," +
                            $"choose from: red, green, blue.");
                }

            }
        }


        public Person this[int index]
        {
            get => Children[index];
            set
            {
                Children[index] = value;
            }
        }

    }
}
